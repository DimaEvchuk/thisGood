﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.TagHelpers
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) => 
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
