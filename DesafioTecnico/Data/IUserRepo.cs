using DesafioTecnico.Models;

namespace DesafioTecnico.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetByCpf(string cpf);
        User GetById(int id);

        void Delete(User user);

        void Update(User user);

        void Creat(User user);

        bool SaveChanges();

        IEnumerable<User> GetAtivos();
    }
}
