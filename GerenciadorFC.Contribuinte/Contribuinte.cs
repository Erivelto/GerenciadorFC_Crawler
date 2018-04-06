using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contribuinte
{
    public class Contribuinte
    {
        public int Codigo { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string CodigoContribuite { get; set; }
        public string Captcha { get; set; }
        public string ValorTributado { get; set; }
        public List<AnexoContribuinte> Anexo { get; set; }
        public string Url { get; set; }
        public string CodigoAntiCaptcha { get; set; }
        public string mesApuracao { get; set; }
        public string anoApuracao { get; set; }
        public string Email { get; set; }
    }
}
