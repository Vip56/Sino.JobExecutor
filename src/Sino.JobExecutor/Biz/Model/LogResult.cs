namespace Sino.JobExecutor.Biz.Model
{
    /// <summary>
    /// 日志结果
    /// </summary>
    public class LogResult
    {
        public LogResult(int fromLineNum, int toLineNum, string logContent, bool isEnd)
        {
            FromLineNum = fromLineNum;
            ToLineNum = toLineNum;
            LogContent = logContent;
            IsEnd = isEnd;
        }

        public int FromLineNum { get; set; }

        public int ToLineNum { get; set; }

        public string LogContent { get; set; }

        public bool IsEnd { get; set; }
    }
}
