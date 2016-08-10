using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using WebClient.Models.Pages;

namespace WebClient.modules.ScheduledJobs
{
    /// <summary>
    /// FRM005
    /// Author: Snehal Jadhav
    /// Purpose of the Class : Create a scheduled job plugin in Episerver Admin
    /// How to use:Write the implementation logic in Execute()
    /// Points to take care: ScheduledPlugIn attribute and inheriting from ScheduledBase is must
    /// </summary>
    [ScheduledPlugIn(DisplayName = "Page Count Job", LanguagePath = "/admin/DeleteJob", DefaultEnabled = true)]
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
            PageDataCollection pages = EPiServer.DataFactory.Instance.GetChildren(ContentReference.RootPage);
            if (pages != null && pages.Count > 0)
            {
                return pages.Count+" pages exists in the current project edit mode.";                
            }

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Job executed successfully. No pages exists.";
        }
    }
}