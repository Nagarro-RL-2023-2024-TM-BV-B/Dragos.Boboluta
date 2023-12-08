using Autofac;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Report;

namespace BankingApp.Fundamentals.OOP
{
    public static class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CreditService>().As<ICreditService>();
            builder.RegisterType<Reporter>().As<IReporter>();

            return builder.Build();
        }
    }
}
