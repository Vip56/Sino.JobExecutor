using Sino.JobExecutor.Biz.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sino.JobExecutor.Biz
{
    /// <summary>
    /// 管理接口
    /// </summary>
    public interface IAdminBiz
    {
        Task<ReturnT<string>> CallBack(IList<HandleCallbackParam> callbackParamList);

        Task<ReturnT<string>> Registry(RegistryParam registryParam);

        Task<ReturnT<string>> RegistryRemove(RegistryParam registryParam);
    }
}
