using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Crawler.Dominios.Prefeituras.CrossCutting
{
    public class RegistrarServicosPrefeitura
    {
        public static Container ContainerPrefeituras { get; set; }

        public static void Initialize(Container container)
        {
            ContainerPrefeituras = container;

            //AQUI VAO AS INTERFACES DOS SERVICOS E REPOSITORIOS

        }
    }
}
