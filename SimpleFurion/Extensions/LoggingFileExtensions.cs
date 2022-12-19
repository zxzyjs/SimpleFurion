using SimpleFurion.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFurion
{
    /// <summary>
    /// 日志写入文件扩展
    /// </summary>
    public static class LoggingFileExtensions
    {
        /// <summary>
        /// 添加workerservice项目日志格式化扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="isLevel">是否根据日志等级记录文件</param>
        /// <returns></returns>
        public static IHostBuilder UseLoggingFile(this IHostBuilder builder, bool isLevel = false)
        {
            //builder.ConfigureLogging(logging =>
            //  {
            //      logging.ClearProviders();
            //      logging.AddConsole(options =>
            //      {
            //          options.FormatterName = "custom_format";
            //      }).AddConsoleFormatter<ConsoleForamt, ConsoleFormatterOptions>();

            //  });
            builder.ConfigureServices((hostContext, services) =>
             {
                 services.AddComponent<LoggingConsoleComponent>();
                 services.AddComponent<LoggingFileComponent>(isLevel);
             });
            return builder;
        }


        /// <summary>
        /// 添加api项目控制台日志格式化扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="isLevel">是否根据日志等级记录文件</param>
        /// <returns></returns>
        public static WebApplicationBuilder UseLoggingFile(this WebApplicationBuilder builder, bool isLevel = false)
        {
            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole(options =>
            //{
            //    options.FormatterName = "custom_format";
            //}).AddConsoleFormatter<ConsoleForamt, ConsoleFormatterOptions>();
            builder.Services.AddComponent<LoggingConsoleComponent>();
            builder.Services.AddComponent<LoggingFileComponent>(isLevel);
            return builder;
        }
    }
}
