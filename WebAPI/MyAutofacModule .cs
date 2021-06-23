using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Project.Services;
using CSharp_Project.Repository;
using CSharp_Project.Repository.iplm;
using CSharp_Project.Models;
using CSharp_Project.Services.iplm;

namespace WebAPI
{
    public class MyAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repository
//            builder.RegisterType<RoleRepository>().As<IRepository<RoleTable>>();

            //Service
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<NewsService>().As<INewsService>();

            //Repository
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<NewsRepository>().As<INewsRepository>();


            // Other Lifetime
            // Transient
            /*            builder.RegisterType<MyService>().As<IService>()
                            .InstancePerDependency();

                        // Scoped
                        builder.RegisterType<MyService>().As<IService>()
                            .InstancePerLifetimeScope();

                        builder.RegisterType<MyService>().As<IService>()
                            .InstancePerRequest();

                        // Singleton
                        builder.RegisterType<MyService>().As<IService>()
                            .SingleInstance();*/

            // Scan an assembly for components
            //builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
            //       .Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces();
        }
    }
}
