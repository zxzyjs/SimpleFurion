using Furion.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFurion.Component
{
    /// <summary>
    /// 日志写入文件的组件
    /// </summary>
    public sealed class LoggingConsoleComponent : IServiceComponent
    {
        public void Load(IServiceCollection services, ComponentContext componentContext)
        {
            services.AddConsoleFormatter(options =>
             {


                 options.MessageFormat = (logMsg) =>
                 {
                     //if (logMsg.LogName != LoggingConst.LoggingMonitor)
                     //{
                     //    var stringBuilder = new StringBuilder();
                     //    stringBuilder.AppendLine("【日志级别】：" + logMsg.LogLevel);
                     //    stringBuilder.AppendLine("【日志类名】：" + logMsg.LogName);
                     //    stringBuilder.AppendLine("【日志时间】：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss(zzz) dddd"));
                     //    stringBuilder.AppendLine("【日志内容】：" + logMsg.Message);
                     //    if (logMsg.Exception != null)
                     //    {
                     //        stringBuilder.AppendLine("【异常信息】：" + logMsg.Exception);
                     //    }
                     //    return stringBuilder.ToString();
                     //}
                     //else
                     //{
                     //    return logMsg.Message;
                     //}
                     var stringBuilder = new StringBuilder();
                     stringBuilder.AppendLine("【日志级别】：" + logMsg.LogLevel);
                     stringBuilder.AppendLine("【日志类名】：" + logMsg.LogName);
                     stringBuilder.AppendLine("【日志时间】：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss dddd"));
                     stringBuilder.AppendLine("【日志内容】：" + logMsg.Message);
                     if (logMsg.Exception != null)
                     {
                         stringBuilder.AppendLine("【异常信息】：" + logMsg.Exception);
                     }
                     return stringBuilder.ToString();

                 };
                 options.WriteHandler = (logMsg, scopeProvider, writer, fmtMsg, opt) =>
                 {
                     ConsoleColor consoleColor = ConsoleColor.White;
                     switch (logMsg.LogLevel)
                     {
                         case LogLevel.Information:
                             consoleColor = ConsoleColor.DarkGreen;
                             break;
                         case LogLevel.Warning:
                             consoleColor = ConsoleColor.DarkYellow;
                             break;
                         case LogLevel.Error:
                             consoleColor = ConsoleColor.DarkRed;
                             break;
                     }
                     if (logMsg.Context != null)
                     {
                         var color = logMsg.Context.Get(LoggingConst.Color);
                         if (color != null)
                         {
                             consoleColor = (ConsoleColor)color;
                         }

                     }
                     writer.WriteWithColor(fmtMsg, ConsoleColor.Black, consoleColor);
                 };
             });


        }
    }
}
