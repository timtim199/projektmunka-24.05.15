using System;

namespace kutyak_infojegyzet_eredeti.Data.Models
{
    internal class Kutya : IModel
    {
        public uint Id { get; set; }
        public KutyaFajta Fajta { get => lazyFajta.Value; }
        public KutyaNev Nev { get => lazyNev.Value; }
        public uint Age { get; set; }
        public DateTime LastMedicalCheck { get; set; }

        private Lazy<KutyaFajta> lazyFajta;
        private Lazy<KutyaNev> lazyNev;
        public Kutya()
        {
        }

        private KutyaFajta GetFajta(uint id)
        {
            return ApplicationWorker.dataContext.KutyaFajtak.FindById(id);
        }

        private KutyaNev GetNev(uint id)
        {
            return ApplicationWorker.dataContext.KutyaNevek.FindById(id);
        }

        public IModel Serialize(string line)
        {
            string[] fields = line.Split(';');

            if (fields.Length == 5)
            {
                if (uint.TryParse(fields[0], out uint id))
                {
                    Id = id;

                    if (uint.TryParse(fields[1], out uint fajta_id))
                    {
                        lazyFajta = new Lazy<KutyaFajta>(() =>
                        {
                            return GetFajta(fajta_id);
                        });

                        if (uint.TryParse(fields[2], out uint nev_id))
                        {
                            lazyNev = new Lazy<KutyaNev>(() =>
                            {
                                return GetNev(nev_id);
                            });

                            if (uint.TryParse(fields[3], out uint age))
                            {
                                Age = age;

                                if (DateTime.TryParse(fields[4], out DateTime lastCheck))
                                {
                                    LastMedicalCheck = lastCheck;
                                    return this;
                                }
                            }
                        }
                    }
                }
            }

            throw new FormatException($"Faile serialization, invalid line: {line}");

        }
    }
}
