using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti.Repository.Models
{
    internal class Kutya : IModel
    {
        public int Id { get; set; }
        public KutyaFajta Fajta { get => fajta.Value;  }
        public KutyaNev Nev { get => nev.Value; }
        public int Age { get; set; }
        public DateTime LastMedicalCheck { get; set; }

        private Lazy<KutyaFajta> fajta;
        private Lazy<KutyaNev> nev;
        public Kutya()
        {
        }

        private KutyaFajta GetFajta(int id)
        {
            return new KutyaFajta();
        }

        private KutyaNev GetNev(int id)
        {
            return new KutyaNev();
        }

        public IModel Serialize(string line)
        {
            int a = 0;
            fajta = new Lazy<KutyaFajta>((() =>
            {
                return GetFajta(a);
            }));
            nev = new Lazy<KutyaNev>((() =>
            {
                return GetNev(a);
            }));

            return this;
        }
    }
}
