using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Infrastructure;
using Services.Entities;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using Services.PageModel;
using EPiServer.Data;
using EPiServer.XForms;

namespace Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        public string PostResult(QuestionnaireEntity Questionnaire)
        {
            #region Save the values in XFORM

            try
            {
                PropertyXForm prop = new PropertyXForm();
                //Save the values to Xform

                // Get the equivalent of DataFactory in CMS 5/6
                var repository = ServiceLocator.Current.GetInstance<IContentRepository>();

                // Get content (page or block) with ID 5
                var contentReference = new ContentReference(Questionnaire.QuestionnaireId);

                // Get the page (or block)
                var page = repository.Get<QuestionnairePageType>(contentReference);

                if (page == null)
                    throw new Exception();

                prop = page.Property["XFormQuestionnaire"] as PropertyXForm;

                if (prop.IsNull)
                    throw new Exception();

                //Creating Xform data to store the fields to form repository
                XFormData formData = prop.Form.CreateFormData();
                formData.UserName = "Public user";
                formData.PageGuid = page.PageGuid;
                formData.ChannelOptions = ChannelOptions.Database;

                formData.SetValue("QUESTION_ID", Questionnaire.questions.FirstOrDefault().QuestionId.ToString());
                formData.SetValue("CORRECT_ANSWER", Questionnaire.questions.FirstOrDefault().Answer);
               
                //Save form data to form       
                formData.Send();
            }
            catch
            {
                
            }
            #endregion
            return "From the service " + Questionnaire.QuestionnaireId;
        }
    }
}
