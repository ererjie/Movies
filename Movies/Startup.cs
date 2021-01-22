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

            //1.΢���һ��д��
            var config = new AppConfig();
            Configuration.GetSection("AppConfig").Bind(config);//bind�������ͣ��ڴ��Ƕ��󣩣�����AppConfig��json�е�AppConfig������ϵ����
            services.AddSingleton(config);//�������õ��������config��Ȼ��ע���ȥ
                                          //AppConfig����ŵ��������ļ��������������ݿ����ӣ�������AddSingleton

            //�����ݿ��й�ϵ�Ķ���AddScoped
            services.AddScoped<IMoviesAccountRepository, MoviesAccountRepository>();//�����ڴ�ÿ���ӿڶ�Ҫ��һ������
            services.AddScoped<IMoviesGroupRepository, MoviesGroupRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            //services.AddScoped();����
            //services.AddTransient();//˲ʱ
            ////2.΢��ڶ���д��
            //Configuration.GetSection("Appconfig:AesKey");
            //Configuration.GetSection("Appconfig:DbConn");
            ////3.�쵼�ķ�װ��һ���Ǻ�AppConfig����һ�£�,��AppConfig���м̳�ITransientConfigModelһ��ʹ��
            //services.AddAutoConfig(Configuration);

            //�������ݿ�
            services.AddDbContext<MoviesDbContext>();

            //services.AddDbContext<MoviesDbContext>(options =>
            // options.UseMySql(Configuration.GetConnectionString("Server=localhost;port=3306;database=movies;uid=root;pwd=root;Convert Zero Datetime=True;")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",         //�汾
                    Title = "MoviesSwagger",     //����
                    Description = "API����",//����
                    Contact = new OpenApiContact   //��ϵ����Ϣ
                    {
                        Name = "ererjie",
                        Email = "1757456497@qq.com",
                    }
                });
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "Movies.xml");//xml·�����ƣ���������
                c.IncludeXmlComments(() =>
                {
                    return new System.Xml.XPath.XPathDocument(xmlPath);
                }, true);
                var entityXmlPath = Path.Combine(basePath, "Movies.Domin.xml");//xml·�����ƣ����������������ʾ����ע�ͣ�
                c.IncludeXmlComments(entityXmlPath, true);//��true���Կ��Ʒ���ֵ��ע�Ϳ����к���ע��


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //�м���ܵ���û��RequestDelegate��next�������ܵ��²���м��������ֻ��ִ�и��м�����ϵ��м�������ܵ����м�����µ��м���У����ܵ���mvc��
            app.UseMiddleware<ExceptionMiddleware>();
            //��������
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
