using ProcesoCRUD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesoCRUD
{
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        #region "MIS METODOS"
        private void LimpiaTexto()
        {
            txtDescripcion_Producto.Text = "";
            txtMarca_Producto.Text = "";
            txtStock_Actual.Text = "0.00";
            cmbCategoria.Text = "";
            cmbMedidas.Text = "";
        }

        private void EstadoTexto(bool lEstado)
        {
            txtDescripcion_Producto.Enabled = lEstado;
            txtMarca_Producto.Enabled = lEstado;
            txtStock_Actual.Enabled = lEstado;
            cmbCategoria.Enabled = lEstado;
            cmbMedidas.Enabled = lEstado;
        }

        private void EstadoBotones(bool lEstado)
        {
            btnCancelar.Visible = !lEstado;
            btnGuardar.Visible = !lEstado;

            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

            btnBuscar.Enabled = lEstado;
            txtBuscar.Enabled = lEstado;
            dgvListado_Productos.Enabled = lEstado;
        }

        private void CargarMedidas()
        {
            D_Productos Datos = new D_Productos();

            cmbMedidas.DataSource = Datos.Listado_Medidas();
            cmbMedidas.ValueMember = "Codigo_Medida";
            cmbMedidas.DisplayMember = "Descripcion_Medida";
        }

        private void CargarCategorias()
        {
            D_Productos Datos = new D_Productos();

            cmbCategoria.DataSource = Datos.Listado_Categorias();
            cmbCategoria.ValueMember = "Codigo_Categoria";
            cmbCategoria.DisplayMember = "Descripcion_Categoria";
        }

        private void FormatoProducto()
        {
            dgvListado_Productos.Columns[0].Width = 80;
            dgvListado_Productos.Columns[0].HeaderText = "Codigo Producto";
            
            dgvListado_Productos.Columns[1].Width = 200;
            dgvListado_Productos.Columns[1].HeaderText = "Producto";
            
            dgvListado_Productos.Columns[2].Width = 100;
            dgvListado_Productos.Columns[2].HeaderText = "Marca";
            
            dgvListado_Productos.Columns[3].Width = 100;
            dgvListado_Productos.Columns[3].HeaderText = "Medida";
            
            dgvListado_Productos.Columns[4].Width = 100;
            dgvListado_Productos.Columns[4].HeaderText = "Categoria";
            
            dgvListado_Productos.Columns[5].Width = 120;
            dgvListado_Productos.Columns[5].HeaderText = "Stock Actual";

            dgvListado_Productos.Columns[6].Visible = false;
            dgvListado_Productos.Columns[7].Visible = false;
        }

        private void ListadoProducto(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            dgvListado_Productos.DataSource = Datos.Listado_Productos(cTexto);
            this.FormatoProducto();
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_Producto.Select();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.CargarMedidas();
            this.CargarCategorias();
            this.ListadoProducto("%");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }
    }
}
