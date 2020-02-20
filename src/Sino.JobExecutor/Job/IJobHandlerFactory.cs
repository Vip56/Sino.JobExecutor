using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.JobExecutor.Job
{
    /// <summary>
    /// <see cref="IJobHandler"/>管理工厂接口
    /// </summary>
    public interface IJobHandlerFactory
    {
        IJobHandler GetJobHandler(string handlerName);
    }
}
