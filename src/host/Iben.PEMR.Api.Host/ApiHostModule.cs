using Iben.PEMR.Api.Domain;
using Iben.PEMR.Api.Repository;
using Iben.PEMR.Api.Service;
using NUglify;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace Iben.PEMR.Api.Host;

[DependsOn(
        typeof(ServiceModule),
        typeof(RepositoryModule),
        typeof(AbpAutofacModule),
        typeof(AbpSwashbuckleModule)
    )]
public class ApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                typeof(Resource),
                typeof(DomainModule).Assembly,
                typeof(ServiceModule).Assembly,
                typeof(ApiHostModule).Assembly
            );
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureApiRequestModelBinder(context);
        ConfigureAutoMapper();
        ConfigureAutoApiControllers();
    }


    private static void ConfigureApiRequestModelBinder(ServiceConfigurationContext context)
    {
        context.Services.AddControllers(options =>
        {
            //options.Filters.Add(typeof(LinkingExceptionFilter));
            //options.ModelBinderProviders.Insert(0, new LinkingDataBinderProvider());
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    }

    private void ConfigureAutoMapper()
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApiHostModule>();
        });
    }

    private void ConfigureAutoApiControllers()
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(ServiceModule).Assembly, abpOptions =>
            {
                abpOptions.UseV3UrlStyle = true;
                abpOptions.RootPath = "v1";//服务窗接口版本
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        //if (!env.IsDevelopment())
        //{
        //    app.UseErrorPage();
        //}


        app.UseCorrelationId();
        app.UseRouting();
        app.UseAuthentication();

        app.UseUnitOfWork();

#if DEBUG //调试模式才开启,手动开启
        //app.UseStaticFiles();
        //app.UseSwagger();
        //app.UseAbpSwaggerUI(options =>
        //{
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API API");
        //});
#endif

        app.UseAuditing();
        //app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
