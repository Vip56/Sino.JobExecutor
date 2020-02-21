using Sino.JobExecutor.Biz.Model;
using Sino.JobExecutor.Core;
using Sino.JobExecutor.Job;
using System.Threading.Tasks;

namespace Sino.JobExecutor
{
    /// <summary>
    /// 实现基于C#的基本执行器对象
    /// </summary>
    public class BeanTaskExecutor : ITaskExecutor
    {
        private readonly IJobHandlerFactory _handlerFactory;
        private readonly IJobLogger _jobLogger;

        public BeanTaskExecutor(IJobHandlerFactory handlerFactory, IJobLogger jobLogger)
        {
            _handlerFactory = handlerFactory;
            _jobLogger = jobLogger;
        }

        public string GlueTypeName => GlueType.BEAN;

        public Task<ReturnT<string>> Execute(TriggerParam triggerParam)
        {
            var handler = _handlerFactory.GetJobHandler(triggerParam.ExecutorHandler);

            if(handler == null)
            {
                return Task.FromResult(new ReturnT<string>(ReturnT<string>.FAIL_CODE, $"job handler [{triggerParam.ExecutorHandler}] not found."));
            }

            var context = new JobExecuteContext(_jobLogger, triggerParam.ExecutorParams);
            return handler.Execute(context);
        }
    }
}
