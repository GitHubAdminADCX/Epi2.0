﻿using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //This is a sample standard service
    public class StandardService : IStandardService
    {
        public string SayHello()
        {
            return "Hello World";
        }
    }
}
