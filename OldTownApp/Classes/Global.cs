using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;

namespace OldTownApp
{
    class Global
    {
        public static User User { set; get; }
        public static MySqlConnection SqlConnection { set; get; }
        public static MySqlCommand SqlCommand { set; get; }
    }
}
