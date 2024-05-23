using kutyak_infojegyzet_eredeti.Data.Models;

namespace kutyak_infojegyzet_eredeti.Data
{
    internal class KutyaFajtaRepository : Repository<KutyaFajta>
    {
        public override string datasetPath => "assets/KutyaFajtak.csv";

    }
}
