using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using GerenciadorFC.Contribuinte;

namespace GerenciadorFC.Repositorio.Mappers
{
    public class ContribuinteMapeamento : EntityTypeConfiguration<Contribuinte.Contribuinte>
    {
        public ContribuinteMapeamento()
        {
            ToTable("Contribuite");
            HasKey(x => x.Codigo);
        }
    }
}
