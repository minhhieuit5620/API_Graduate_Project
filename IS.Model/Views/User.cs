using IS.Model.Manager;
using ISCommon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Model.Views
{
    public class User:TblAdmin
    {
    }
    public class UserReturnModel : ErrorMessage
    {
        public List<User> Data { get; set; }
        public int TotalRecord { get; set; }
        public int pages { get; set; }
    }
    public class UserModelParameter
    {
        public User Data { get; set; }
        public PageParameter Page { get; set; }

    }
}
