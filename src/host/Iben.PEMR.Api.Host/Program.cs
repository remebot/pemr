namespace Iben.PEMR.Api.Host
{
    public class Program
    {
        public async static Task<int> Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Host.UseAutofac();

                // Add services to the container.
                await builder.AddApplicationAsync<ApiHostModule>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }


                await app.InitializeApplicationAsync();
                await app.RunAsync();

                return 0;
            }
            catch(Exception ex)
            {
                return 1;
            }
            finally
            {

            }
        }
    }
}
