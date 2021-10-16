using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
  
    public class User
    {
 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public int Remarks { get; set; }
        [NotMapped]
        public int SerialId { get; set; }

    }
    public class UserListModel
    {
        public List<User> userList { get; set; }
    }
}
