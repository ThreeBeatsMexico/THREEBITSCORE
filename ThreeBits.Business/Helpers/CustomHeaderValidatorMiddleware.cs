﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Filters;

namespace ThreeBits.Business.Helpers
{
    public class CustomHeaderValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _headerName;


        public CustomHeaderValidatorMiddleware(RequestDelegate next, string headerName)
        {
            _next = next;
            _headerName = headerName;
        }


        public async Task Invoke(HttpContext context)
        {
            if (IsHeaderValidated(context))
            {
                await _next.Invoke(context);
            }
            else
            {
                throw new Exception($"the header {_headerName} is mandatory and it is missing");
            }

        }

        private bool IsHeaderValidated(HttpContext context)
        {
            Endpoint? endpoint = context.GetEndpoint();
            if (endpoint == null)
                return true;

            bool isRequired = IsHeaderRequired(endpoint);
            if (!isRequired)
                return true;

            bool isIncluded = IsHeaderIncluded(context);

            if (isRequired && isIncluded)
                return true;

            return false;
        }

        private bool IsHeaderIncluded(HttpContext context)
            => context.Request.Headers.Keys.Select(a => a.ToLower()).Contains(_headerName.ToLower());

        private static bool IsHeaderRequired(Endpoint endpoint)
        {
            var attribute = endpoint.Metadata.GetMetadata<ICustomAttribute>();

            return attribute is { IsMandatory: true };
        }
    }
}