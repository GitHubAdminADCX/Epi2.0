using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Services.Entities;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQuestionnaireService" in both code and config file together.
    //[ServiceContract]
    public interface IQuestionnaireService
    {
        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "PostResult")]
        string PostResult(QuestionnaireEntity Questionnaire);
    }
}
