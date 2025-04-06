namespace Duckpond.TimeTracker.Common.Services;

public abstract class GenericRepository<TModel> : IRepository<TModel> where TModel : BaseModel
{
    protected IList<TModel> Models { get; set; } = new List<TModel>();

    public TModel? GetById(int id)
    {
        return Models.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<TModel> GetAll()
    {
        return Models;
    }

    public void Add(TModel model)
    {
        Models.Add(model);
    }

    public void Update(TModel model)
    {
        Models.Remove(model);
        Models.Add(model);
    }

    public void Delete(int id)
    {
        var employee = GetById(id);
        if (employee is null) return;
        Delete(employee);
    }

    public void Delete(TModel model)
    {
        Models.Remove(model);
    }

    public abstract void Load();

    public abstract void Save();
}