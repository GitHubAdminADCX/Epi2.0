using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Models.ViewModels
{

    /// <summary>
    /// Defines common characteristics for view models for pages, including properties used by layout files.
    /// </summary>
    /// <remarks>
    /// Views which should handle several page types (T) can use this interface as model type rather than the
    /// concrete PageViewModel class, utilizing the that this interface is covariant.
    /// </remarks>
    public interface IPageViewModel<out T> where T : PageData
    {
        T CurrentPage { get; }      
        IContent Section { get; set; }
    }
}
