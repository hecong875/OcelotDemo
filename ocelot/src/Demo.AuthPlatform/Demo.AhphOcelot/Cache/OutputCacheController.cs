using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocelot.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.AhphOcelot.Cache
{
    [Authorize]
    [Route("outputcaches")]
    public class OutputCacheController : Controller
    {
        private readonly IOcelotCache<CachedResponse> _cache;

        public OutputCacheController(IOcelotCache<CachedResponse> cache)
        {
            _cache = cache;
        }

        [HttpDelete]
        [Route("{region}")]
        public IActionResult Delete(string region)
        {
            _cache.ClearRegion(region);
            return new NoContentResult();
        }

    }
}
