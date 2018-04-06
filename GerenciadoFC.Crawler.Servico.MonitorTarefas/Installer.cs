using GerenciadorFC.Crawler.Dominios.Nucleo.Aplicacao.Interfaces;
using GerenciadorFC.Crawler.Dominios.Prefeituras.CrossCutting;
using Hangfire;
using Hangfire.MySql;
using Hangfire.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadoFC.Crawler.Servico.MonitorTarefas
{
    public partial class Installer : ServiceBase
    {
        private BackgroundJobServer _server;

        public Installer()
        {
            InitializeComponent();

            

            Container container = ContainerConfigura();

            RegistrarServicosPrefeitura.Initialize(container);

            JobStorage.Current = new MySqlStorage("GerenciadorCrawler");

            var activator = new SimpleInjectorJobActivator(container);
            _server = new BackgroundJobServer(new BackgroundJobServerOptions
            {

                Activator = activator,
                ServerName = "Monitor Serviço Nota Fiscal"
            }, JobStorage.Current);



            var recurringJobs = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(
                        type =>
                            typeof(IRecurringJob).IsAssignableFrom(type) &&
                            !type.IsAbstract &&
                            !type.IsGenericTypeDefinition &&
                            !type.IsInterface);

            container.RegisterCollection<IRecurringJob>(recurringJobs);

            container.Verify();
        }

        protected override void OnStart(string[] args)
        {
            var recurringJobsInstances = RegistrarServicosPrefeitura.ContainerPrefeituras.GetAllInstances<IRecurringJob>();

            using (AsyncScopedLifestyle.BeginScope(RegistrarServicosPrefeitura.ContainerPrefeituras))
            {
                JobBootstrapper jobs = new JobBootstrapper(recurringJobsInstances);

                jobs.Bootstrap();
            }
        }

        protected override void OnStop()
        {
            RegistrarServicosPrefeitura.ContainerPrefeituras.Dispose();
        }

        public Container ContainerConfigura()
        {
            Container container = new Container();

            container.Options.DefaultScopedLifestyle = Lifestyle.CreateHybrid(
                   defaultLifestyle: new AsyncScopedLifestyle(),
                   fallbackLifestyle: new ThreadScopedLifestyle());

            container.Options.DefaultLifestyle = Lifestyle.CreateHybrid(
                   defaultLifestyle: new AsyncScopedLifestyle(),
                   fallbackLifestyle: new ThreadScopedLifestyle());


            return container;
        }
    }
}
