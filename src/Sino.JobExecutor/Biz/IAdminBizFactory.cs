using System.Collections.Generic;

namespace Sino.JobExecutor.Biz
{
    /// <summary>
    /// <see cref="IAdminBiz"/>接口工厂接口
    /// </summary>
    public interface IAdminBizFactory
    {
        /// <summary>
        /// 创建接口对象
        /// </summary>
        IAdminBiz GetService();

        IReadOnlyList<IAdminBiz> GetAll();
    }
}
