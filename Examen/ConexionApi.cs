﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace Examen
{
    public static class ConexionApi
    {
        public static HttpClient WebApiClient = new HttpClient();

        static ConexionApi()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:61960/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}