using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Services.Infrastructure;
using Services;

namespace IoC.Registration
{
    /// <summary>
    /// Configuration for EPi services and repositories
    /// </summary>
    public class Epiregistration : IRegistration
    {
        public void RegisterInterception(Container container)
        {
            throw new NotImplementedException();
        }

        public void RegisterRepositories(Container container)
        {
            container.RegisterSingleton<IStandardService, StandardService>();
            container.RegisterSingleton<IQuestionnaireService, QuestionnaireService>();
        }

        public void RegisterServices(Container container)
        {   
            container.RegisterSingleton<IStandardService, StandardService>();
            container.RegisterSingleton<IQuestionnaireService, QuestionnaireService>();
        }        
    }
}
