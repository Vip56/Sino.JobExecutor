using System.Threading.Tasks;
using Sino.JobExecutor.Biz.Model;

namespace Sino.JobExecutor.Job
{
    /// <summary>
    /// <see cref="IJobHandler"/>的抽象基类
    /// </summary>
    public abstract class JobHandler : IJobHandler
    {
        protected ReturnT<string> Success { get; } = new ReturnT<string>(200, null);

        protected ReturnT<string> Fail { get; } = new ReturnT<string>(500, null);

        protected ReturnT<string> FailTimeout { get; } = new ReturnT<string>(502, null);

        public abstract Task<ReturnT<string>> Execute(JobExecuteContext context);
    }
}
