using DesafioTecnico.Models;

namespace DesafioTecnico.Data
{
    public class UserRepo : IUserRepo
    {
        private UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }

        IEnumerable<User> IUserRepo.GetUsers()
        {
            return _context.Users.ToList();
        }

        User IUserRepo.GetByCpf(string cpf)
        {
            return _context.Users.FirstOrDefault(user => user.UserCPF == cpf); 
        }

        User IUserRepo.GetById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.UserId == id);
        }

        void IUserRepo.Delete(User user)
        {
           _context.Users.Remove(user);
        }

        public void Update(User user)
        {
           _context.Users.Update(user);
        }

        public void Creat(User user)
        {
            _context.Users.Add(user);
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<User> GetAtivos()
        {
            return _context.Users.Where(user => user.UserAtivo);
        }

    }
}
