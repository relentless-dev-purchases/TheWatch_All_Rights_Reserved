///-------------------------------------------------------------------------------------------------
/// <summary>
///     In development, always fetch from the network and do not enable offline support. This is
///     because caching would make development more difficult (changes would not be reflected on
///     the first load after each change).
/// </summary>
///
/// <remarks>   Broadsides, 9/14/2023. </remarks>
///
/// <param name="'fetch'">  The 'fetch'. </param>
/// <param name="(">        The (. </param>
///
/// <returns>   . </returns>
///-------------------------------------------------------------------------------------------------

self.addEventListener('fetch', () => { });
