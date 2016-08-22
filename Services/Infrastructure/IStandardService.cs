using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.Infrastructure
{   
    //This is a standard inteface for service
    public interface IStandardService
    {
        string SayHello();       
    }
}
