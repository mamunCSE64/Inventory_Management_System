using Inventory_Management_System.InheritDB;
using Inventory_Management_System.Models;
using MyApp.Infrastructure.Repositorys.IRepository;

namespace MyApp.Infrastructure.Repositorys.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyAppDbContext _Context;
        public AuthorRepository(MyAppDbContext context)
        {
            _Context = context;
        }

      
       
       
    }
}
