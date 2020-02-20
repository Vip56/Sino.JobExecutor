using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace Sino.JobExecutor.Job
{
    /// <summary>
    /// 默认工厂实现
    /// </summary>
    public class DefaultJobHandlerFactory : IJobHandlerFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ConcurrentDictionary<string, IJobHandler> _handlersCache;

        public DefaultJobHandlerFactory(IEnumerable<IJobHandler> jobHandlers)
        {
            _handlersCache = new ConcurrentDictionary<string, IJobHandler>();
            

        }

        public IJobHandler GetJobHandler(string handlerName)
        {
            throw new NotImplementedException();
        }
    }
}
