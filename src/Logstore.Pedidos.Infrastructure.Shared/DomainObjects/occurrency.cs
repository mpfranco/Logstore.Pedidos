﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Logstore.Pedidos.Infrastructure.Shared.DomainObjects
{
    public class occurrency
    {
        public List<occurrences> occurrences { get; set; }
        public string errorCode { get; set; }
        public string message { get; set; }
        public int status { get; set; }        
        
    }
}
