using Sino.JobExecutor.Biz.Model;
using System.Threading.Tasks;

namespace Sino.JobExecutor.Core
{
    /// <summary>
    /// 负责提供任务执行基本接口，如果需要实现支持多种语言需要实现该接口并注入。
    /// </summary>
    public interface ITaskExecutor
    {
        string GlueType { get; }

        Task<ReturnT<string>> Execute(TriggerParam triggerParam);
    }
}
