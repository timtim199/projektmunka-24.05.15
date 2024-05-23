using kutyak_infojegyzet_eredeti.Data.Models;
using System;

namespace kutyak_infojegyzet_eredeti.Data
{
    internal class KutyaNevRepository : Repository<KutyaNev>
    {
        public override string datasetPath => "assets/KutyaNevek.csv";

        public override void ApplicationReady(object sender, EventArgs e)
        {
            Console.WriteLine($"[3. feladat] Kutyanevek száma: {dataset.Count}");
        }
    }
}
