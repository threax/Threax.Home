using Microsoft.Extensions.DependencyInjection;

namespace Threax.Home.MFi
{
    internal class AppConfig
    {
        public ExceptionFilterOptions ExceptionOptions { get; set; } = new ExceptionFilterOptions();
    }
}