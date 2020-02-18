using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.JobExecutor.Biz.Model
{
    public class ReturnT<T> where T : class
    {
        public static int SUCCESS_CODE = 200;
        public static int FAIL_CODE = 500;



        public ReturnT() { }

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
