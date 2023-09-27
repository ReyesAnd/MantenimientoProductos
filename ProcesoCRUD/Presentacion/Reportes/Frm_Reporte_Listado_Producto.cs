using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCRUD.Presentacion.Reportes
{
    public partial class Frm_Reporte_Listado_Producto : Form
    {
        public Frm_Reporte_Listado_Producto()
        {
            InitializeComponent();
        }

        private void Frm_Respuesta_Listado_Producto_Load(object sender, EventArgs e)
        {
            this.uSP_Listado_ProductoTableAdapter.Fill(this.dS_Reportes.USP_Listado_Producto, cTexto:txt_01.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
