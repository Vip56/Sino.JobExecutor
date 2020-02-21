using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

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
            
            if (jobHandlers == null || !jobHandlers.Any())
            {
                throw new ArgumentNullException(nameof(jobHandlers));
            }

            foreach(var handler in jobHandlers)
            {
                var jobHandlerAttr = handler.GetType().GetCustomAttribute<JobHandlerAttribute>();
                var handlerName = jobHandlerAttr == null ? handler.GetType().Name : jobHandlerAttr.Name;
                if (_handlersCache.ContainsKey(handlerName))
                {
                    throw new Exception($"Same IJobHandler Name: {handlerName}.");
                }
                _handlersCache.TryAdd(handlerName, handler);
            }
        }

        public IJobHandler GetJobHandler(string handlerName)
        {
            if (_handlersCache.ContainsKey(handlerName))
            {
                IJobHandler handler = null;
                if(_handlersCache.TryGetValue(handlerName, out handler))
                {
                    return handler;
                }
            }
            return null;
        }
    }
}
