using DependencyInjection_Sample;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceCollectionAndServiceProviderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ICar, MockCar>();

            //Der Magic Bereich - Ende der Startup 
            ServiceProvider provider = serviceCollection.BuildServiceProvider(); //Bei Drittanbieter wie AutoFac oder Ninject, wird die Provider-Klasse ausgetauscht. 



            //Beim Call eines Controllers, wird in Konstruktor nach den Parametern geschaut
            ICar mockCar = provider.GetRequiredService<ICar>();

        }
    }
}
