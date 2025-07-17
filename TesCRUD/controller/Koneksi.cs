using System;
using System.Collections.Generic;
using System.Data; //tambahin
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //tambahin

namespace TesCRUD.controller
{
    class Koneksi
    {
        string cs = "Server=localhost;Database=dbrumahsakit;Uid=root;Pwd=brajs01$;";
        MySqlConnection con;

        public void OpenCon()
        {
            con = new MySqlConnection(cs);
            con.Open();
        }
        public void CloseCon()
        {
            con.Close();
        }

        public void ExecuteQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }   

        public object ShowData(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, cs);
            DataSet data = new DataSet();
            adapter.Fill(data);
            object datas = data.Tables[0];
            return datas;
        }
    }
}
