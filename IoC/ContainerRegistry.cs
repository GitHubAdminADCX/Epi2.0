using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using IoC.Registration;

namespace IoC
{
    /// <summary>
    /// Container registration implementation
    /// </summary>
    public static class ContainerRegistry
    {
        private static Container _container;
        private static Container _uncachedcontainer;

        //[System.Diagnostics.DebuggerStepThrough]
        public static TService GetInstance<TService>()
            where TService : class
        {
            if (_container == null)
            {
                ContainerRegistration();
            }
            return _container.GetInstance<TService>();
        }

        public static TService GetUnCachedInstance<TService>()
            where TService : class
        {
            if (_uncachedcontainer == null)
            {
                ContainerRegistration();
            }
            return _uncachedcontainer.GetInstance<TService>();
        }

        /// <summary>
        /// Registers container
        /// </summary>
        public static void ContainerRegistration()
        {

            List<IRegistration> registrations = GetRegistrations().ToList();

            // 1. Create a new Simple Injector container
            var container = new Container();
            var uncachedcontainer = new Container();

            // 2. Configure the container (register)
           // registrations.ForEach(R => R.RegisterRepositories(container));
            registrations.ForEach(R => R.RegisterServices(container));
            //registrations.ForEach(R => R.RegisterInterception(container));

            //registrations.ForEach(R => R.RegisterRepositories(uncachedcontainer));
            //registrations.ForEach(R => R.RegisterServices(uncachedcontainer));

            // 3. Optionally verify the container's configuration.
            container.Verify();
            uncachedcontainer.Verify();

            // 4. Store the container for use by Page classes.
            _container = container;
            _uncachedcontainer = uncachedcontainer;
        }

        private static IEnumerable<IRegistration> GetRegistrations()
        {
            yield return new Epiregistration();           
        }
    }
}
