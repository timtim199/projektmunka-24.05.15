using kutyak_infojegyzet_eredeti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti
{
    internal static class ApplicationWorker
    {
        public static void Start()
        {
            new KutyaRepository().LoadDataset();
        }
    }
}
