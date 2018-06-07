namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExcenstions
    {
        /// <summary>
        ///    注册服务
        ///    如果该服务已经注册过了，那就让本次的实现成为第一个注入的实例
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <param name="registerService"></param>
        public static void FirstRegister<TService, TImplementation>(this IServiceCollection services, RegisterService<TService, TImplementation> registerService)
            where TService : class
            where TImplementation : class, TService
        {
            int first = -1;

            for (int i = 0; i < services.Count; i++)
            {
                if (services[i].ServiceType == typeof(TService))
                {
                    first = i;
                    break;
                }
            }

            if(first == -1)
            {
                //  第一次注入，就按原来的方式
                registerService(services);
            }
            else
            {
                IServiceCollection newServicesCollection = new ServiceCollection();

                foreach (var item in services)
                {
                    if(first-- == 0)
                    {
                        //  新的服务成为第一个注入的
                        registerService(newServicesCollection);
                    }
                    newServicesCollection.Add(item);
                }

                services.Clear();

                foreach (var service in newServicesCollection)
                {
                    services.Add(service);
                }
            }
        }

        /// <summary>
        ///     这个委托可以让 FirstRegister 方法的参数以委托的方式穿进来
        ///     但是遗憾的是不能友好的融合拓展方法，此时还要在调用 FirstRegister 显示指出泛型参数
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public delegate IServiceCollection RegisterService<TService, TImplementation>(IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
            ;
    }
}
