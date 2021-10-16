using ModelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataAccess
{
    public class UserRepository
    {
        UserDBContext context = null;
        public UserRepository(UserDBContext dataContext)
        {
            context = dataContext;
        }

        public List<User> GetAll()
        {
            return context.Set<User>().ToList();
        }


        public int Insert(User entity)
        {
            int res = 0;
            try
            {
                context.Set<User>().Add(entity);
                res = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }


}
