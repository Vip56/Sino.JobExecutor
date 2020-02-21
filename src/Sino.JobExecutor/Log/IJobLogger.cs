using Sino.JobExecutor.Biz.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.JobExecutor
{
    /// <summary>
    /// 任务日志接口
    /// </summary>
    public interface IJobLogger
    {
        /// <summary>
        /// 设置日志文件
        /// </summary>
        void SetLogFile(long logTime, int logId);

        void Log(string pattern, params object[] format);

        void LogError(Exception ex);

        LogResult ReadLog(long logTime, int logId, int fromLine);

        void LogSpecialFile(long logTime, int logId, string pattern, params object[] format);
    }
}
