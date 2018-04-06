using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorFC.Prestador;
using GerenciadorFC.Tomador;
using GerenciadorFC.Contribuinte;


namespace AppTeste
{
    class Program
    {
        static void Main(string[] args)
        {

            //var receita = new GerenciadorFC.Robo.Receita.DAS.ReceitaDAS();
            //var prestador = new Prestador();
            //var tomador = new Tomador();

            //var prestador = new Prestador();
            //var tomador = new Tomador();
            var contribuinte = new Contribuinte();
            //tomador = AppTeste.Aruja.get_Tomador();
            //prestador = AppTeste.Aruja.get_Prestador();
            contribuinte = AppTeste.ReceitaDAS.get_contribuite();

            //var guarulhosNfe = new GerenciadorFC.Robo.Guarulhos.GeradorNfe();
            //var arujaNfe = new GerenciadorFC.Robo.Aruja.GeradorNfe();
            //var arujaCancel = new GerenciadorFC.Robo.Aruja.CancelaNfe();
            //var arujaConsulta = new GerenciadorFC.Robo.Aruja.ConsultaNFe();
            //var itaquaNfe = new GerenciadorFC.Robo.Itaquaquecetuba.ConsultaNfe();
            //tomador = AppTeste.Guarulhos.get_Tomador();
            //prestador = AppTeste.Guarulhos.get_Prestador();
           // var saoPaulo = new GerenciadorFC.Robo.SaoPaulo.GeradorNfe();
            //tomador = AppTeste.Aruja.get_Tomador();
            //prestador = AppTeste.Aruja.get_Prestador();

            //tomador = AppTeste.Guarulhos.get_Tomador();
            //prestador = AppTeste.Guarulhos.get_Prestador();

            //Task.Run(() => guarulhosNfe.Emissor(prestador, tomador)).Wait();
            //Task.Run(() => saoPaulo.AcessarReceita()).Wait();
            //Task.Run(() => receita.AcessarReceita()).Wait();
            var geraImposto = new GerenciadorFC.Robo.Receita.DAS.ReceitaDAS();

            geraImposto.EmissorImpostos(contribuinte);

            //Task.Run(() => guarulhosNfe.Emissor(prestador, tomador)).Wait();
            //string nfe =  arujaNfe.Emissor(prestador, tomador);

            //arujaNfe.Emissor(prestador, tomador);

           // arujaConsulta.Consulta("43", prestador);
            ///
            ///itaquaNfe.Emissor(prestador, tomador);
            //itaquaNfe.Consulta("739", prestador);
           // saoPaulo.Emissor(prestador, tomador);
            //arujaCancel.Cancelar("43", prestador);

        }
    }
}
