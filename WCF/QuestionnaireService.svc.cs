using IoC;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Services.Entities;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QuestionnaireService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select QuestionnaireService.svc or QuestionnaireService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract(Namespace = "QuestionnaireService")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class QuestionnaireService : Services.IQuestionnaireService
    {
        [OperationContract]
        //[WebInvoke(Method = "POST",BodyStyle=WebMessageBodyStyle.Bare,UriTemplate = "PostResult",RequestFormat =WebMessageFormat.Json)]
        [WebInvoke(RequestFormat = WebMessageFormat.Json)]
        public string PostResult(QuestionnaireEntity Questionnaire)
        {
            // Add your operation implementation here
            //Get the Comment Service
            var service = ContainerRegistry.GetInstance<IQuestionnaireService>();
            //Gets comment or page
            var result = service.PostResult(Questionnaire);
            return result;
        }
    }
}
