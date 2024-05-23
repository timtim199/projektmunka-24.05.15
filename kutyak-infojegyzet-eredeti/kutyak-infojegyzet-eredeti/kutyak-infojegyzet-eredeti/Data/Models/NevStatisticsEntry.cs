namespace kutyak_infojegyzet_eredeti.Data.Models
{
    internal class NevStatisticsEntry
    {
        public KutyaNev Nev { get; set; }
        public int Count { get; set; }

        public NevStatisticsEntry(KutyaNev nev, int count)
        {
            Count = count;
            Nev = nev;
        }

        public override string ToString()
        {
            return $"{Nev.Nev};{Count}";
        }
    }
}
