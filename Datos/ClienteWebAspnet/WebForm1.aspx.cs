using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ClienteWebAspnet.ProxyProductos;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Web;
using ClienteWebAspnet.proxyProductosWcf;

namespace ClienteWebAspnet
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //wsProductosSoapClient ws = new wsProductosSoapClient();
        IwcfProductosClient ws = new IwcfProductosClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = ws.DevolverTodosLosProductos();
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = ws.DevolverTodosLosProductosDescontinuados();
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = ws.DevolverTodosLosProductosConStockCero();
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = ws.DevolverTodosLosProductosConRiesgoCaducarse();
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Excel
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Crear un nuevo libro de Excel
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Crear una nueva hoja de trabajo en el libro
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Obtener los encabezados de las columnas del DataGridView
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = GridView1.Columns[i].HeaderText;
            }

            // Obtener los datos de las filas del DataGridView
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                for (int j = 0; j < GridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = GridView1.Rows[i].Cells[j];
                }
            }

            // Guardar el archivo de Excel
            string fileName = "datos.xlsx";
            string filePath = HttpContext.Current.Server.MapPath("~/" + fileName);
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            // Descargar el archivo de Excel
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
            HttpContext.Current.Response.WriteFile(filePath);
            HttpContext.Current.Response.End();
        }
    }

      
}
