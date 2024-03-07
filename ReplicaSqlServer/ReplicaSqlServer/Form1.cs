using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplicaSqlServer
{
    public partial class Form1 : Form
    {
        Conexion conexion;
        public Form1()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillCombo(col1Tipo);
            fillCombo(col2Tipo);
            fillCombo(col3Tipo);
            fillCombo(col4Tipo);
            fillCombo(col5Tipo);
        }
        private void fillCombo(ComboBox c)
        {
            c.Items.Add("VARCHAR(70)");
            c.Items.Add("CHARACTER(1)");
            c.Items.Add("INTEGER");
            c.Items.Add("DOUBLE");
            c.Items.Add("NUMERIC(10,2)");
        }

        private void crearBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tabName.Text) && (string.IsNullOrWhiteSpace(col1Name.Text) || string.IsNullOrWhiteSpace(col2Name.Text) || string.IsNullOrWhiteSpace(col3Name.Text) || string.IsNullOrWhiteSpace(col4Name.Text) || string.IsNullOrWhiteSpace(col5Name.Text)))
            {
                System.Windows.Forms.MessageBox.Show("Ingresar nombre de tabla y al menos una columna");
            }
            else
            {
                string query = "create table " + tabName.Text + " (" + queryBuilder(col1Name, col1Tipo, col1Pk) + queryBuilder(col2Name, col2Tipo, col2Pk) + queryBuilder(col3Name, col3Tipo, col3Pk) + queryBuilder(col4Name, col4Tipo, col4Pk) + queryBuilder(col5Name, col5Tipo, col5Pk) + ")";
                string redTab = "select name from sysibm.systables where creator  = 'USUARIO'";

                conexion.sendCmd(query);
                conexion.fillDataGrid(this.dataGridView1, redTab);
            }
        }


        
        private string queryBuilder(TextBox t, ComboBox c, CheckBox cb)
        {
            string value = "";
            if (!string.IsNullOrWhiteSpace(t.Text) && !string.IsNullOrWhiteSpace(c.Text) && cb.Checked == true)
            {
                if (checkIfOne())
                {
                    value = t.Text + " " + c.Text + " not null primary key";
                }
                else
                {
                    value = t.Text + " " + c.Text + " not null primary key";
                }
            }
            else if (!string.IsNullOrWhiteSpace(t.Text) && !string.IsNullOrWhiteSpace(c.Text))
            {
                value = "," + t.Text + " " + c.Text;
            }
            else if (!string.IsNullOrWhiteSpace(t.Text))
            {
                value = t.Text + ",";
            }
            return value;
        }

        private bool checkIfOne()
        {
            if (!string.IsNullOrEmpty(col1Name.Text) && (string.IsNullOrEmpty(col2Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col5Name.Text)))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(col2Name.Text) && (string.IsNullOrEmpty(col1Name.Text) && string.IsNullOrEmpty(col3Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col5Name.Text)))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(col3Name.Text) && (string.IsNullOrEmpty(col2Name.Text) && string.IsNullOrEmpty(col1Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col5Name.Text)))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(col4Name.Text) && (string.IsNullOrEmpty(col2Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col1Name.Text) && string.IsNullOrEmpty(col5Name.Text)))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(col5Name.Text) && (string.IsNullOrEmpty(col2Name.Text) && string.IsNullOrEmpty(col3Name.Text) && string.IsNullOrEmpty(col4Name.Text) && string.IsNullOrEmpty(col1Name.Text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
