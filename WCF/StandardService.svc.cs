using IoC;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    [ServiceContract(Namespace = "StandardService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StandardService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public string SayHello()
        {
            // Add your operation implementation here
            //Get the Comment Service
            var service = ContainerRegistry.GetInstance<IStandardService>();
            //Gets comment or page
            var result = service.SayHello();
            return result;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
