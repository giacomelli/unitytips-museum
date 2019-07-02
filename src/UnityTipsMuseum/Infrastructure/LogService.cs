using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace UnityTipsMuseum.Infrastructure
{
    // I tried to use https://github.com/BlazorExtensions/Logging with Blazor 3.0.0-preview6.19307.2, but after install the package the dotnet build broken.
    public class LogService
    {
        IJSRuntime _js;
        public LogService(IJSRuntime js)
        {
            _js = js;
        }
        public async Task Debug(object message)
        {
            await _js.InvokeAsync<object>("console.log", message);
        }

        public async Task Info(object message)
        {
            await _js.InvokeAsync<object>("console.info", message);
        }

        public async Task Warn(object message)
        {
            await _js.InvokeAsync<object>("console.warn", message);
        }

        public async Task Error(object message)
        {
            await _js.InvokeAsync<object>("console.error", message);
        }
    }
}