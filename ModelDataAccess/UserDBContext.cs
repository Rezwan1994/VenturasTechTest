using ModelEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDataAccess
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private UserDBContext() { }
        private static UserDBContext context = null;
        public static UserDBContext getInstance()
        {
            if (context == null)
            {
                context = new UserDBContext();
                return context;
            }
            return context;
        }
    }

}
