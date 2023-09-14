
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TheWatch.App.Utilities
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A custom authentication state provider. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        /// <summary>   (Immutable) the HTTP client. </summary>
        private readonly HttpClient _httpClient;
        /// <summary>   (Immutable) the local storage. </summary>
        private readonly ILocalStorageService _localStorage;
        /// <summary>   (Immutable) the jwt security token handler. </summary>
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="httpClient">               The HTTP client. </param>
        /// <param name="localStorage">             The local storage. </param>
        /// <param name="jwtSecurityTokenHandler">  The jwt security token handler. </param>
        ///-------------------------------------------------------------------------------------------------

        public JwtAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage, JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Asynchronously gets an <see cref="T:Microsoft.AspNetCore.Components.Authorization.AuthenticationState" />
        ///     that describes the current user.
        /// </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <returns>
        ///     A task that, when resolved, gives an <see cref="T:Microsoft.AspNetCore.Components.Authorization.AuthenticationState" />
        ///     instance that describes the current user.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var accessToken = await _localStorage.GetItemAsStringAsync("access_token");

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var token = _jwtSecurityTokenHandler.ReadJwtToken(accessToken);
            var expiresAt = token.ValidTo;

            if (expiresAt < DateTime.UtcNow)
            {
                await _localStorage.RemoveItemAsync("access_token");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(accessToken), "jwt_auth_type")));
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Enumerates parse claims from jwt in this collection. </summary>
        ///
        /// <remarks>   Broadsides, 9/14/2023. </remarks>
        ///
        /// <param name="jwt">  The jwt. </param>
        ///
        /// <returns>
        ///     An enumerator that allows foreach to be used to process parse claims from jwt in this
        ///     collection.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var token = _jwtSecurityTokenHandler.ReadJwtToken(jwt);

            claims.AddRange(token.Claims);

            return claims;
        }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for local storage service. </summary>
    ///
    /// <remarks>   Broadsides, 9/14/2023. </remarks>
    ///-------------------------------------------------------------------------------------------------

    internal interface ILocalStorageService
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets item as string asynchronous. </summary>
        ///
        /// <param name="v">    A string to process. </param>
        ///
        /// <returns>   The item as string. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task<string> GetItemAsStringAsync(string v);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Removes the item asynchronous described by v. </summary>
        ///
        /// <param name="v">    A string to process. </param>
        ///
        /// <returns>   A Task. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task RemoveItemAsync(string v);
    }
}
