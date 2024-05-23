namespace kutyak_infojegyzet_eredeti.Data
{
    internal class DataContext
    {
        public KutyaRepository Kutyak { get => kutyaRepository; }
        public KutyaFajtaRepository KutyaFajtak { get => kutyaFajtaRepository; }
        public KutyaNevRepository KutyaNevek { get => kutyaNevRepository; }

        private readonly KutyaRepository kutyaRepository;
        private readonly KutyaFajtaRepository kutyaFajtaRepository;
        private readonly KutyaNevRepository kutyaNevRepository;

        public DataContext()
        {
            kutyaFajtaRepository = new KutyaFajtaRepository();
            kutyaNevRepository = new KutyaNevRepository();
            kutyaRepository = new KutyaRepository();

            KutyaNevek.LoadDataset();
            KutyaFajtak.LoadDataset();
            Kutyak.LoadDataset();
        }

    }
}
