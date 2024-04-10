using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Iben.PEMR.Api.Repository;

public class RepositoryModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        //暂时不用这种懒方法，强制熟悉abp框架，所以注释
        //context.Services.Add(ServiceDescriptor.Singleton(typeof(IBaseRepository<>), typeof(BaseRepository<>)));
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
