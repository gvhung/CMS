using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Core.Model
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Usertype { get; set; }
        public string Status { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long UID { get; set; }
    }
    public class UserCreateModel:UserViewModel
    {
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
       
    }
    public class UserListModel
    {
        public long PageNo { get; set; }
        public int PageSize { get; set; }
        public IList<UserViewModel> Users { get; set; }

    }
}
