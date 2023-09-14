
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheWatch.Client;
using TheWatch.Shared.OpenAPI;

/// <summary>   The builder. </summary>
var builder = WebAssemblyHostBuilder.CreateDefault(args);

///-------------------------------------------------------------------------------------------------
/// <summary>   Constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <typeparam name="App">  Type of the application. </typeparam>
/// <param name="parameter1">   The first parameter. </param>
///-------------------------------------------------------------------------------------------------

builder.RootComponents.Add<App>("#app");

///-------------------------------------------------------------------------------------------------
/// <summary>   Constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <typeparam name="HeadOutlet">   Type of the head outlet. </typeparam>
/// <param name="parameter1">   The first parameter. </param>
///-------------------------------------------------------------------------------------------------

builder.RootComponents.Add<HeadOutlet>("head::after");

/// <summary>   URL of the resource. </summary>
var url = builder.HostEnvironment.BaseAddress;

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });

///-------------------------------------------------------------------------------------------------
/// <summary>   Default constructor. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///-------------------------------------------------------------------------------------------------

builder.Services.AddScoped(sp => new AppServices(url, new HttpClient()));

///-------------------------------------------------------------------------------------------------
/// <summary>   Executes the 'asynchronous' operation. </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <returns>   A Tuple. </returns>
///-------------------------------------------------------------------------------------------------

await builder.Build().RunAsync();
