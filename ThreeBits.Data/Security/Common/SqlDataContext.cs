using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Data.Common
{
    public class SqlDataContext
    {
        private const int COMMANDTIMEOUT = 180;
        protected string _connectionString;
        protected SqlConnection _sqlConnection = null;

        /// <summary>
        /// Connect
        /// </summary>
        /// <returns></returns>
        public bool Connect(out string dbException)
        {
            dbException = string.Empty;
            try
            {
                _sqlConnection = new SqlConnection(_connectionString);

                if (_sqlConnection.State != ConnectionState.Open)
                {
                    _sqlConnection.Open();
                }
                return true;
            }
            catch (Exception excp)
            {
                dbException = excp.Message;
                return false;
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Executes an SQL statement. For UPDATE, INSERT, and DELETE statements.
        /// </summary>
        /// <param name="command">SQL statement of the command. The connection and transaction will be used when the command is executed if they are given.</param>
        /// <returns>Return value is the number of rows affected; for all other statements, it is -1. Returns the InvalidOperationException error if the connection does not exist or is not open.</returns>
        public bool ExecuteNonQuery(ref SqlCommand command, out int rowsAffected, out string dbException, int commandTimeout = COMMANDTIMEOUT)
        {
            rowsAffected = 0;
            try
            {
                if (Connect(out dbException))
                {
                    command.Connection = _sqlConnection;
                    command.CommandTimeout = commandTimeout;
                    rowsAffected = command.ExecuteNonQuery();
                    Disconnect();
                    command.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception excp)
            {
                dbException = excp.Message;
                Disconnect();
                command.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Executes an query.
        /// </summary>
        /// <param name="command">SQL statement of the command. The connection and transaction will be used when the command is executed if they are given.</param>
        /// <returns>Returns the first column of the first row in the result set returned by the query. Extra columns or rows are ignored.</returns>
        public bool ExecuteScalar(ref SqlCommand command, out dynamic scalar, out string dbException, int commandTimeout = COMMANDTIMEOUT)
        {
            scalar = null;
            try
            {
                if (Connect(out dbException))
                {
                    command.Connection = _sqlConnection;
                    command.CommandTimeout = commandTimeout;
                    scalar = command.ExecuteScalar();
                    Disconnect();
                    command.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception excp)
            {
                dbException = excp.Message;
                Disconnect();
                command.Dispose();
                return true;
            }
        }

        /// <summary>
        /// Executes the command in the CommandText property against the IfxConnection object and builds an IfxDataReader object. 
        /// </summary>
        /// <param name="command">SQL statement of the command. The connection and transaction will be used when the command is executed if they are given.</param>
        /// <param name="behavior">        
        /// CloseConnection—When the command is executed, the IfxConnection object is closed when the associated IfxDataReader object is closed.
        /// Default—The query can return multiple result sets. Execution of the query can affect the database state. The default sets no CommandBehavior flags.
        /// KeyInfo—The query returns column and primary key information. The query is executed without any locking on the selected rows.
        /// SchemaOnly—The query returns column information only and does not affect the database state.
        /// SequentialAccess—Provides a way for the IfxDataReader object to handle rows that contain columns with large binary values. Rather than loading the entire row, the SequentialAccess parameter enables the IfxDataReader object to load data as a stream. You can then use the IfxDataReader.
        /// SingleResult—The query returns a single result set. Execution of the query can affect the database state.
        /// SingleRow—The query is expected to return a single row. Execution of the query can affect the database state. If you expect your SQL statement to return only one  row, specifying the SingleRow parameter can improve application performance.
        /// </param>
        /// <returns>Loads a datatable with the resultset and prints the output</returns>
        public bool ExecuteReader(ref SqlCommand command, out DataTable reader, out string dbException, CommandBehavior behavior = CommandBehavior.Default, string TableName = "tabla", int commandTimeout = COMMANDTIMEOUT)
        {
            reader = null;
            try
            {
                if (Connect(out dbException))
                {
                    command.Connection = _sqlConnection;
                    command.CommandTimeout = commandTimeout;
                    SqlDataReader DataReader = command.ExecuteReader(behavior);
                    reader = new DataTable(TableName);
                    reader.Load(DataReader);
                    DataReader.Close();
                    Disconnect();
                    command.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception excp)
            {
                Disconnect();
                command.Dispose();
                dbException = excp.Message;
                return false;
            }
        }

        //public IEnumerable<dynamic> GetDynamicResult(string commandText, params SqlParameter[] parameters)
        //{
        //    string dbException;
        //    // Get the connection from DbContext
        //    var connection = Connect(out dbException);

        //    // Open the connection if isn't open
        //    if (connection.State != System.Data.ConnectionState.Open)
        //        connection.Open();

        //    using (var command = connection.CreateCommand())
        //    {
        //        command.CommandText = commandText;
        //        command.Connection = connection;

        //        if (parameters?.Length > 0)
        //        {
        //            foreach (var parameter in parameters)
        //            {
        //                command.Parameters.Add(parameter);
        //            }
        //        }

        //        using (var dataReader = command.ExecuteReader())
        //        {
        //            // List for column names
        //            var names = new List<string>();

        //            if (dataReader.HasRows)
        //            {
        //                // Add column names to list
        //                for (var i = 0; i < dataReader.VisibleFieldCount; i++)
        //                {
        //                    names.Add(dataReader.GetName(i));
        //                }

        //                while (dataReader.Read())
        //                {
        //                    // Create the dynamic result for each row
        //                    var result = new ExpandoObject() as IDictionary<string, object>;

        //                    foreach (var name in names)
        //                    {
        //                        // Add key-value pair
        //                        // key = column name
        //                        // value = column value
        //                        result.Add(name, dataReader[name]);
        //                    }

        //                    yield return result;
        //                }
        //            }
        //        }
        //    }
        //}

        public bool ExecuteReaderCustom(ref SqlCommand command, out SqlDataReader reader, out string dbException, CommandBehavior behavior = CommandBehavior.Default, string TableName = "tabla", int commandTimeout = COMMANDTIMEOUT)
        {
            reader = null;
            try
            {
                if (Connect(out dbException))
                {
                    command.Connection = _sqlConnection;
                    command.CommandTimeout = commandTimeout;
                    SqlDataReader DataReader = command.ExecuteReader(behavior);
                    //reader = new DataTable(TableName);
                    //reader.Load(DataReader);
                    DataReader.Close();
                    Disconnect();
                    command.Dispose();
                    return true;
                }
                return false;
            }
            catch (Exception excp)
            {
                Disconnect();
                command.Dispose();
                dbException = excp.Message;
                return false;
            }
        }



        public class DbDataContextException : Exception
        {
            public DbDataContextException(string message) : base(message) { }
            public DbDataContextException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
