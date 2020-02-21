using System;
using System.Collections.Generic;
using System.Text;
using Sino.JobExecutor.Biz.Model;

namespace Sino.JobExecutor.Log
{
    /// <summary>
    /// 任务日志，主要提供计算任务记录日志并供调度中心拉取
    /// </summary>
    public class JobLogger : IJobLogger
    {
        public void Log(string pattern, params object[] format)
        {
            throw new NotImplementedException();
        }

        public void LogError(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogSpecialFile(long logTime, int logId, string pattern, params object[] format)
        {
            throw new NotImplementedException();
        }

        public LogResult ReadLog(long logTime, int logId, int fromLine)
        {
            throw new NotImplementedException();
        }

        public void SetLogFile(long logTime, int logId)
        {
            throw new NotImplementedException();
        }
    }
}
