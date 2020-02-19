using System;
using System.Collections.Generic;
using System.IO;

namespace Sino.JobExecutor.Config
{
    /// <summary>
    /// 执行器参数
    /// </summary>
    public class ExecutorOptions
    {
        public ExecutorOptions()
        {
            AppName = "xxl-job-executor-dotnet";
            LogPath = Path.Combine(AppContext.BaseDirectory, "./logs");
            LogRetentionDays = 30;
            CallBackInterval = 500;
        }

        /// <summary>
        /// 管理地址
        /// </summary>
        public List<string> AdminAddresses { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 本地绑定的IP地址，为空则自动获取
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 本地绑定端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 是否自动注册
        /// </summary>
        public bool AutoRegistry { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 日志路径
        /// </summary>
        public string LogPath { get; set; }

        /// <summary>
        /// 日志保留天数
        /// </summary>
        public int LogRetentionDays { get; set; }

        /// <summary>
        /// 回调时间间隔，单位毫秒
        /// </summary>
        public int CallBackInterval { get; set; }
    }
}
