using System;

namespace kutyak_infojegyzet_eredeti.Data.Models
{
    internal class KutyaFajta : IModel
    {
        public uint Id { get; set; }
        public string Nev { get; set; }
        public string EredetiNev { get; set; }

        public IModel Serialize(string line)
        {
            string[] fields = line.Split(';');

            if (fields.Length == 3)
            {
                if (uint.TryParse(fields[0], out uint id))
                {
                    Id = id;
                    if (!string.IsNullOrEmpty(fields[1]))
                    {
                        Nev = fields[1];
                        if (!string.IsNullOrEmpty(fields[2]))
                        {
                            EredetiNev = fields[2];
                            return this;
                        }
                    }
                }
            }
            throw new FormatException($"Faile serialization, invalid line: {line}");

        }
    }
}
