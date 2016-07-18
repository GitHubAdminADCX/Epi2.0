using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.PlugIn;
using EPiServer.Scheduler;

namespace WebClient.modules.ScheduledJobs
{
    /// <summary>
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Create a scheduled job plugin in Episerver Admin
    /// How to use:Write the implementation logic in Execute()
    /// Points to take care: ScheduledPlugIn attribute and inheriting from ScheduledBase is must
    /// </summary>
    [ScheduledPlugIn(DisplayName = "Delete old data", LanguagePath = "/admin/DeleteJob", DefaultEnabled = true)]
    public class DeleteJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public DeleteJob()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Logic for deletion
        /// </summary>
        /// <returns></returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

            //Add implementation logic 

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Change to message that describes outcome of execution";
        }
    }
}