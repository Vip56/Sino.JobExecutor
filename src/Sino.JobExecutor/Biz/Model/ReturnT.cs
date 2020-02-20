namespace Sino.JobExecutor.Biz.Model
{
    /// <summary>
    /// 响应数据模型
    /// </summary>
    public class ReturnT<T> where T : class
    {
        public static int SUCCESS_CODE = 200;
        public static int FAIL_CODE = 500;

        public static ReturnT<string> SUCCESS = new ReturnT<string>(null);
        public static ReturnT<string> FAIL = new ReturnT<string>(FAIL_CODE, null);

        public ReturnT() { }

        public ReturnT(T content)
        {
            Code = SUCCESS_CODE;
            Content = content;
        }

        public ReturnT(int code, string msg)
        {
            Code = code;
            Msg = msg;
        }

        public int Code { get; set; }

        public string Msg { get; set; }

        public T Content { get; set; }
    }
}
