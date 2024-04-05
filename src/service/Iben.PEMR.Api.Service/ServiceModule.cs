using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.AutoMapper;

namespace Iben.PEMR.Api.Service;

public class ServiceModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        //DtoExtensions.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ServiceModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ServiceModule>();
        });
    }
}
