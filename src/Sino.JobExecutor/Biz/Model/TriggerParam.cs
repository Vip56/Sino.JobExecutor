namespace Sino.JobExecutor.Biz.Model
{
    /// <summary>
    /// 触发执行任务参数
    /// </summary>
    public class TriggerParam
    {
        public int JobId { get; set; }

        public string ExecutorHandler { get; set; }

        public string ExecutorParams { get; set; }

        public string ExecutorBlockStrategy { get; set; }

        public int ExecutorTimeout { get; set; }

        public long LogId { get; set; }

        public long LogDateTime { get; set; }

        public string GlueType { get; set; }

        public string GlueSource { get; set; }

        public long GlueUpdatetime { get; set; }

        public int BroadcastIndex { get; set; }

        public int BroadcastTotal { get; set; }
    }
}
