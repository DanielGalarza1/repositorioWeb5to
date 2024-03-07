using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplicaSqlServer
{
    internal class Conexion
    {
        Connect connect = new Connect("Server = localhost:50000; Database = DBNAMES; UID = USUARIO; PWD = smonkw33d");
        internal void fillDataGrid(DataGridView dataGridView1, string redTab)
        {
            try
            {
                connect.Open();
                DB2DataAdapter da = new DB2DataAdapter(query, connect);
                DataSet ds = new DataSet();
                da.Fill(ds);
                d.DataSource = ds.Tables[0];

                d.Update();
                d.Refresh();
                connect.Close();
            }
            catch (DB2Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                connect.Close();
            }
        }

        internal void sendCmd(string query)
        {
            DB2Command cmd = new DB2Command(query, connect);
            connect.Open();
            try
            {
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (DB2Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                connect.Close();
            }
        }
    }
}
