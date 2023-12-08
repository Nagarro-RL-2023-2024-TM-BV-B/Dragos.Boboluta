using Autofac;
using BankingApp.Fundamentals.OOP.Credit;
using BankingApp.Fundamentals.OOP.Report;

namespace BankingApp.Fundamentals.OOP
{
    public static class ServiceRegister
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CreditService>().As<ICreditService>();
            builder.RegisterType<ReportCreator>().As<IReportCreator>();

            return builder.Build();
        }

    }
}
