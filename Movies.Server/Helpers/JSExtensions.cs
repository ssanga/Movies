using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Server.Helpers
{
    public static class JSExtensions
    {
        public static async ValueTask<bool> ConfirmAsync(this IJSRuntime source, string message)
        {
            var result = await source.InvokeAsync<bool>("confirm", message);

            return result;
        }
    }
}
