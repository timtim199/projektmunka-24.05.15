using kutyak_infojegyzet_eredeti.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti.Repository
{
    internal class KutyaFajtaRepository : Repository<KutyaFajta>
    {
        public override string datasetPath => "assets/KutyaFajtak.csv";

    }
}
