
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace TheWatch.Server.Pages
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Error handling of REST API services. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   ReuqestId of HTTP. </summary>
        ///
        /// <value> The identifier of the request. </value>
        ///-------------------------------------------------------------------------------------------------

        public string? RequestId { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Whether ReuqestId is shown. </summary>
        ///
        /// <value> True if show request identifier, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary>   (Immutable) the logger. </summary>
        private readonly ILogger<ErrorModel> _logger;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Error handling model. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="logger">   The logger. </param>
        ///-------------------------------------------------------------------------------------------------

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   OnGet. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///-------------------------------------------------------------------------------------------------

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}