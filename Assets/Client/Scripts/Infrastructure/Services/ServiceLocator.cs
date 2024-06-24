namespace Client.Scripts.Infrastructure.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator instance;
        public static ServiceLocator Container => instance ??= new ServiceLocator();

        public void RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        // I could have done it in a more conventional way
        // with Dictionary like in bootstrapper or smth else.
        // but i wanted to play around with this unpopular solution
        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}