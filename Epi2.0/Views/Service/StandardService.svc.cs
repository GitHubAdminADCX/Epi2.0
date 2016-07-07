using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Services.Infrastructure;
using SimpleInjector;
using IoC;
using System.ServiceModel.Activation;

namespace WebClient.Views.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StandardService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StandardService.svc or StandardService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StandardService
    {
        /// <summary>
        /// Get comment for page
        /// </summary>
        /// <param name="HelloWorld"></param>
        /// <returns></returns>
        [OperationContract]    
        public string GetComments(long pageid)
        {
            //Get the Comment Service
            var service = ContainerRegistry.GetInstance<IStandardService>();
            //Gets comment or page
            var result = service.SayHello();

            return result;
        }
    }
}
