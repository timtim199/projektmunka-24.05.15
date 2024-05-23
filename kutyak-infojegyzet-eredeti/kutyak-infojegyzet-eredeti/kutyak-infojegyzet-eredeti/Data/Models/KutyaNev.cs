using System;

namespace kutyak_infojegyzet_eredeti.Data.Models
{
    internal class KutyaNev : IModel
    {
        public uint Id { get; set; }
        public string Nev { get; set; }

        public IModel Serialize(string line)
        {
            string[] fields = line.Split(';');

            if (fields.Length == 2)
            {
                if (uint.TryParse(fields[0], out uint id))
                {
                    Id = id;
                    if (!string.IsNullOrEmpty(fields[1]))
                    {
                        Nev = fields[1];
                        return this;
                    }
                }
            }
            throw new FormatException($"Faile serialization, invalid line: {line}");

        }
    }
}
