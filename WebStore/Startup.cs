using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebStore
{
    public class Startup
    {
        // В данном свойстве будет храниться конфигурация приложения
        // на время прохождения процесса конфигурации
        /// <summary>
        /// Свойство для доступа к конфигурации
        /// </summary>
        public IConfiguration Configuration { get; }

        // Конструктор класса вызывается инфраструктурой ASP.NET Core
        // Инфраструктура переза выполнением конструктора исследует требуемый
        // ему набор параметров и передаёт их ему в случае, если они ей
        // известны. В противном случае будет сгенерировано исключение
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Данный метод вызывается инфраструктурой ASP.NET Core сразу
        // после завершения работы конструктора.
        // Его основное предназначение - добавить (объявить) все сервисы,
        // которые впоследствии потребуются при работе приложения
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем сервисы, необходимые для mvc
            services.AddMvc();
        }

        // Данный метод вызвается инфраструктурой ASP.NET Core по завершении
        // объявления сервисов. Его предназначение - сконфигурировать сервисы
        public void Configure(
            IApplicationBuilder app, // Объект с параметрами приложения
            IHostingEnvironment env) // Объект с параметрами хоста
        {
            // Используется ли режим отладки
            if (env.IsDevelopment())
            {
                // Разрешаем отображать подробную страницу с информацией 
                // о возникающем исключении
                app.UseDeveloperExceptionPage();
            }

            // Включает с работу со статичскими файлами
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                // Добавляем обработчик маршрута по умолчанию
                routes.MapRoute(
                name: "default",
                template: "{controller=Employee}/{action=Index}/{id?}");
            });

            var hello = Configuration["MyHelloWorld"];

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(hello);
            });
        }
    }
}
