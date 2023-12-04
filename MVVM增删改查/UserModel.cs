using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM增删改查
{
    // Model
    public class UserModel
    {
        private string username = "向天龙";

        public string Username { get => username; set => username = value; }
    }
}
