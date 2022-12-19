using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFurion.Component
{
    public sealed class ConsoleForamtComponent : IWebComponent
    {
        public void Load(WebApplicationBuilder builder, ComponentContext componentContext)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole(options =>
            {
                options.FormatterName = "custom_format";
            }).AddConsoleFormatter<ConsoleForamt, ConsoleFormatterOptions>();

        }


    }
}
