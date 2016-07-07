using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace IoC.Registration
{
    /// <summary>
    /// Contract for registrations
    /// </summary>
    public interface IRegistration
    {
        void RegisterServices(Container container);
        void RegisterRepositories(Container container);
        void RegisterInterception(Container container);
    }
}
