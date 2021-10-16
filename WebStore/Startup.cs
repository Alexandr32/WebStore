using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.DomainNew.Entities;
using WebStore.Infrastructure.Implementation;
using WebStore.Infrastructure.Intefaces;

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

            // Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddDbContext<WebStoreContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Добавляем сервис для аутентификации
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();
            // Опции для аутентификации
            services.Configure<IdentityOptions>(option =>
            {
                // Настройка размера пароля
                option.Password.RequiredLength = 6;
                // Получает или задает флаг, указывающий, должен ли пароль содержать цифру.
                // По умолчанию true.
                option.Password.RequireDigit = false;
                // Получает или задает флаг, указывающий, должны ли пароли содержать символ ASCII в нижнем регистре.
                // По умолчанию true.
                option.Password.RequireLowercase = false;
                // Получает или задает флаг, указывающий, должны ли пароли содержать символ ASCII в верхнем регистре.
                // По умолчанию true.
                option.Password.RequireUppercase = false;
                //Получает или задает флаг, указывающий, должны ли пароли содержать не буквенно - цифровой символ.
                // По умолчанию true.
                option.Password.RequireNonAlphanumeric = false;

                // Получает или задает System.TimeSpan, для которого пользователь заблокирован при возникновении блокировки.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                option.Lockout.MaxFailedAccessAttempts = 10;
                // Получает или задает флаг, указывающий, можно ли заблокировать нового пользователя.
                option.Lockout.AllowedForNewUsers = false;

                // флаг, указывающий, требует ли приложение уникальные электронные письма
                option.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(100);
                options.LoginPath = "/Account/Login";
                // Если логин не указан, ASP.NET Core по умолчанию будет /Account/Login
                options.LogoutPath = "/Account/Logout";
                // Если LogoutPath не установлен здесь, ASP.NET Core по умолчанию будет / Account / Logout
                options.AccessDeniedPath = "/Account/AccessDenied";
                // Если AccessDeniedPath не установлен здесь, ASP.NET Core по умолчанию будет / Account / AccessDenied
                options.SlidingExpiration = true;
            });

            // Настройки для корзины
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // ICartService используется на уровне запроса
            services.AddScoped<ICartService, CookieCartService>(); 
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

            app.UseWelcomePage("/welcome");

            // Использовать ауктонтификацию
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                // Добавляем обработчик маршрута по умолчанию
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });

            //var hello = Configuration["MyHelloWorld"];

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(hello);
            //});
        }
    }
}
