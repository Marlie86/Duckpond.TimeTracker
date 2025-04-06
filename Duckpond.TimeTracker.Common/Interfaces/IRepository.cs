namespace Duckpond.TimeTracker.Common.Interfaces;

public interface IRepository<TModel>
{
    TModel? GetById(int id);
    IEnumerable<TModel> GetAll();
    void Add(TModel model);
    void Update(TModel model);
    void Delete(int id);
    void Delete(TModel model);
    abstract void  Load();
    abstract void Save();
}