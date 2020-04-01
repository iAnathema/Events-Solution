using AutoMapper;
using EventsPortal.AppSettings;
using EventsPortal.BLL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EventsPortal.API.Configuration
{
    public static class Scoped
    {
        public static IServiceCollection AddMappingAndScoped(this IServiceCollection services)
        {
            //Add here repository services
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            Console.WriteLine($"Add Scopes from the assembly Business Logic {Settings.BLLAssembly}");
            services.AddScopedByInterface<IUnitOfWork>(Settings.BLLAssembly);


            return services;
        }

        public static void AddScopedByInterface<T>(this IServiceCollection services, string assemblyString)
        {

            Assembly.Load(assemblyString).GetTypesAssignableFrom<T>().ForEach((t) =>
            {
                Console.WriteLine($"{t.Name}");
                services.AddScoped(typeof(T), t);
            });
        }

        public static List<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
        {
            return assembly.GetTypesAssignableFrom(typeof(T));
        }
        public static List<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType)
        {
            List<Type> ret = new List<Type>();
            foreach (var type in assembly.DefinedTypes)
            {
                if (compareType.IsAssignableFrom(type) && compareType != type)
                {
                    ret.Add(type);
                }
            }
            return ret;
        }

    }
}
