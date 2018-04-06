using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Dominios.Nucleo.Aplicacao.Interfaces
{
    public interface IRecurringJob
    {
        Task Execute();

        string CronExpression();
    }
}
