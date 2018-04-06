using System;
using System.Threading.Tasks;
using GerenciadorFC.Monitor.DashBoard;
using Hangfire;
using Hangfire.MySql;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(Startup))]

namespace GerenciadorFC.Monitor.DashBoard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseStorage(new MySqlStorage("GerenciadorCrawler"));

            app.UseHangfireDashboard();
        }
    }
}
