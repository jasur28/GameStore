namespace GameStore.BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();

        TModel GetById(Guid id);

        void Add(TModel model);

        void Update(TModel model);

        void Delete(Guid id);
    }
}
