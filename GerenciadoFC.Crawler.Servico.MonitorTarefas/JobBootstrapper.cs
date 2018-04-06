using GerenciadorFC.Crawler.Dominios.Nucleo.Aplicacao.Interfaces;
using Hangfire;
using Hangfire.Common;
using System.Collections.Generic;

namespace GerenciadoFC.Crawler.Servico.MonitorTarefas
{
    public class JobBootstrapper
    {
        private readonly IEnumerable<IRecurringJob> _recurringJobs;

        public JobBootstrapper(IEnumerable<IRecurringJob> recurringJobs)
        {
            _recurringJobs = recurringJobs;
        }

        public void Bootstrap()
        {
            var manager = new RecurringJobManager();

            foreach (var job in _recurringJobs)
            {
                var type = job.GetType();
                var method = type.GetMethod("Work");
                var j = new Job(type, method);

                manager.AddOrUpdate(type.Name, j, job.CronExpression());
            }
        }
    }
}
