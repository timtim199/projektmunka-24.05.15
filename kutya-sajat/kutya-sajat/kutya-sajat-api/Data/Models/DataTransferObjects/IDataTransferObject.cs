namespace kutya_sajat_api.Data.Models.DataTransferObjects
{
    public interface IDataTransferObject<T> where T : class, IModel
    {
        public T GetAsDatabaseModel();
        public T ParseIntoDatabaseModel(T model);
    }
}
