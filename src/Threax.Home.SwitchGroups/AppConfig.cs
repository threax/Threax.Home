using Microsoft.Extensions.DependencyInjection;

namespace Threax.Home.SwitchGroups
{
    class AppConfig
    {
        public string ConnectionString { get; internal set; }

        public ExceptionFilterOptions ExceptionOptions { get; set; } = new ExceptionFilterOptions();
    }
}