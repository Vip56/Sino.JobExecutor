namespace Sino.JobExecutor.Biz.Model
{
    /// <summary>
    /// 调度中心回调请求参数
    /// </summary>
    public class HandleCallbackParam
    {
        public HandleCallbackParam() { }

        public HandleCallbackParam(long logId, long logDateTime, ReturnT<string> executeResult)
        {
            LogId = logId;
            LogDateTime = logDateTime;
            ExecuteResult = executeResult;
        }

        public long LogId { get; set; }

        public long LogDateTime { get; set; }

        public ReturnT<string> ExecuteResult { get; set; }
    }
}
