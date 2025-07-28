using joyeriafront.Shared;

public interface IJoyaService
{
    Task<List<Joya>> GetAll();
    Task<Joya?> GetById(int id);
    Task<Joya?> Create(Joya joya);
    Task<Joya?> Update(Joya joya);
    Task Delete(int id);
}

