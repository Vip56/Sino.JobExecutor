using Sino.JobExecutor.Biz.Model;
using Sino.JobExecutor.Core;
using Sino.JobExecutor.Job;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.JobExecutor
{
    /// <summary>
    /// 实现基于C#的基本执行器对象
    /// </summary>
    public class BeanTaskExecutor : ITaskExecutor
    {
        private readonly IJobHandlerFactory jobHandlerFactory;

        public string GlueType => throw new NotImplementedException();

        public Task<ReturnT<string>> Execute(TriggerParam triggerParam)
        {
            throw new NotImplementedException();
        }
    }
}
