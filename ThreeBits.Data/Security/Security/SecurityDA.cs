﻿using Microsoft.Extensions.Configuration;

            var dbCommand = new SqlCommand("sp_getPermisoXApp")

        var dbCommand = new SqlCommand("sp_updSubMenuXAppRol")
        {
            CommandType = CommandType.StoredProcedure
        };
        dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = idPermisoMenu;
        dbCommand.Parameters.Add("@IDPERMISOSSUBMENU", SqlDbType.BigInt).Value = IdPermisoSubmenu;
        dbCommand.Parameters.Add("@NOMBRESUBMENU", SqlDbType.VarChar).Value = SumMenu;
        dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
        dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = TpoObj;
        dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
        dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
        dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
        dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Activo;

        if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
        {
            return DataTable;
        }
        else throw new DbDataContextException(dbError);
            var dbCommand = new SqlCommand("sp_insRolXApp")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@ROL", SqlDbType.VarChar).Value = Rol;
            dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
           
            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);



            DataTable oRes = new DataTable();
                var dbCommand = new SqlCommand("sp_insMetodosxApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDMETODOS", SqlDbType.BigInt).Value = item.IDMETODOS;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = item.IDAPLICACION;
                dbCommand.Parameters.Add("@IDSERVICIOS", SqlDbType.BigInt).Value = item.IDSERVICIOS;
                dbCommand.Parameters.Add("@NOMBREMETODO", SqlDbType.VarChar).Value = item.NOMBREMETODO;
                dbCommand.Parameters.Add("@RECURRENTE", SqlDbType.Bit).Value = item.RECURRENTE;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = item.ACTIVO;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    return DataTable;
                }
                else throw new DbDataContextException(dbError);
            }
            return oRes;
           
               var dbCommand = new SqlCommand("sp_insServicioWCF")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = Servicio;
                

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    return DataTable;
                }
                else throw new DbDataContextException(dbError);  

            var dbCommand = new SqlCommand("sp_insSubMenuXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDPERMISOSMENU", SqlDbType.BigInt).Value = IdSubMenu;
            dbCommand.Parameters.Add("@NOMBRESUBMENU", SqlDbType.VarChar).Value = SubMenu;
            dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
            dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = Obj;
            dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
            dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
            dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;

            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);

            var dbCommand = new SqlCommand("sp_insMenuXAppRol")
            {
                CommandType = CommandType.StoredProcedure
            };
            dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol;
            dbCommand.Parameters.Add("@NOMBREMENU", SqlDbType.VarChar).Value = Menu;
            dbCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar).Value = Img;
            dbCommand.Parameters.Add("@TIPOOBJETO", SqlDbType.VarChar).Value = Obj;
            dbCommand.Parameters.Add("@URL", SqlDbType.VarChar).Value = Url;
            dbCommand.Parameters.Add("@TOOLTIP", SqlDbType.VarChar).Value = Tool;
            dbCommand.Parameters.Add("@ORDEN", SqlDbType.BigInt).Value = Orden;
            if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
            {
                return DataTable;
            }
            else throw new DbDataContextException(dbError);
        }