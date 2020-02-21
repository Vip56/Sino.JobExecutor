using System;

namespace Sino.JobExecutor.Job
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class JobHandlerAttribute : Attribute
    {
        public JobHandlerAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public bool Ignore { get; set; }
    }
}
