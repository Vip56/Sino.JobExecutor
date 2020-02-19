namespace Sino.JobExecutor.Biz.Model
{
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
