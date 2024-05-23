namespace kutyak_infojegyzet_eredeti.Data.Models
{
    internal interface IModel
    {
        public uint Id { get; set; }
        public IModel Serialize(string line);
    }
}
