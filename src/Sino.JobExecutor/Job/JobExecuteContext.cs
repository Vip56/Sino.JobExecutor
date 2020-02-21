namespace Sino.JobExecutor.Job
{
    /// <summary>
    /// Job执行上下文对象
    /// </summary>
    public class JobExecuteContext
    {
        public JobExecuteContext(IJobLogger jobLogger, string jobParameter)
        {
            JobParameter = jobParameter;
            JobLogger = jobLogger;
        }

        public string JobParameter { get; }

        public IJobLogger JobLogger { get; }
    }
}
