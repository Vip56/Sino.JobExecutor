namespace Sino.JobExecutor.Biz.Model
{
    /// <summary>
    /// 执行器注册参数
    /// </summary>
    public class RegistryParam
    {
        public RegistryParam() { }

        public RegistryParam(string registryGroup, string registryKey, string registryValue)
        {
            RegistryGroup = registryGroup;
            RegistryKey = registryKey;
            RegistryValue = registryValue;
        }
        
        public string RegistryGroup { get; set; }

        public string RegistryKey { get; set; }

        public string RegistryValue { get; set; }
    }
}
