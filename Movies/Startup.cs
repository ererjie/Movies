using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Movies.Domin.Interface;
using Movies.Infrastructure;
using Movies.Infrastructure.Middlewares;
using Movies.Respository.Mysql;
using Movies.Respository.Mysql.ImplementInterface;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Movies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //1.微软第一种写法
            var config = new AppConfig();
            Configuration.GetSection("AppConfig").Bind(config);//bind复杂类型（在此是对象），将类AppConfig和json中的AppConfig对象联系起来
            services.AddSingleton(config);//单例：拿到具体对象config，然后注入进去
                                          //AppConfig里面放的是配置文件，不仅仅是数据库连接，所以用AddSingleton

            //和数据库有关系的都用AddScoped
            services.AddScoped<IMoviesAccountRepository, MoviesAccountRepository>();//请求（在此每个接口都要有一个请求）
            services.AddScoped<IMoviesGroupRepository, MoviesGroupRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            //services.AddScoped();请求
            //services.AddTransient();//瞬时
            ////2.微软第二种写法
            //Configuration.GetSection("Appconfig:AesKey");
            //Configuration.GetSection("Appconfig:DbConn");
            ////3.领导的封装（一种是和AppConfig类名一致）,和AppConfig类中继承ITransientConfigModel一块使用
            //services.AddAutoConfig(Configuration);

            //连接数据库
            services.AddDbContext<MoviesDbContext>();

            //services.AddDbContext<MoviesDbContext>(options =>
            // options.UseMySql(Configuration.GetConnectionString("Server=localhost;port=3306;database=movies;uid=root;pwd=root;Convert Zero Datetime=True;")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",         //版本
                    Title = "MoviesSwagger",     //标题
                    Description = "API描述",//描述
                    Contact = new OpenApiContact   //联系人信息
                    {
                        Name = "ererjie",
                        Email = "1757456497@qq.com",
                    }
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "Movies.xml");//xml路径名称（控制器）
                c.IncludeXmlComments(() =>
                {
                    return new System.Xml.XPath.XPathDocument(xmlPath);
                }, true);
                var entityXmlPath = Path.Combine(basePath, "Movies.Domin.xml");//xml路径名称（参数类里面可以显示汉字注释）
                c.IncludeXmlComments(entityXmlPath, true);//加true可以控制返回值的注释可以有汉字注释


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //中间件管道（没有RequestDelegate（next），不能到下层的中间件，所以只能执行该中间件以上的中间件，不能到该中间件以下的中间件中，不能到达mvc）
            app.UseMiddleware<ExceptionMiddleware>();
            //跨域请求
            app.UseCors(builder => builder
               .AllowAnyOrigin()
               .WithMethods("GET", "POST", "OPTIONS")
               .WithHeaders("Content-Type", "UserAuthorization")
               .AllowCredentials()
               .SetPreflightMaxAge(TimeSpan.FromHours(12))
           );

            //    if (env.IsDevelopment())
            //    {
            //        app.UseDeveloperExceptionPage();
            //    }
            //    else
            //    {
            //        app.UseExceptionHandler("/Error");
            //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //        app.UseHsts();
            //    }

            //    app.UseHttpsRedirection();
            //    app.UseStaticFiles();
            //    app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "V1");
                // c.ValidatorUrl(null);
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
