using ProcesoCRUD.Datos;
using ProcesoCRUD.Entidades;
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

        #region "MIS VARIABLES"
        int nEstadoGuarda = 0;
        int vCodigoProducto = 0;
        #endregion

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

        private void SeleccionaItemProducto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Codigo_Producto"].Value)))
            {
                MessageBox.Show("Seleccione un producto.",
                                "Aviso de sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.vCodigoProducto = Convert.ToInt32(dgvListado_Productos.CurrentRow.Cells["Codigo_Producto"].Value);

                txtDescripcion_Producto.Text = Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Descripcion_Producto"].Value);
                txtMarca_Producto.Text = Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Marca_Producto"].Value);
                cmbMedidas.Text = Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Descripcion_Medida"].Value);
                cmbCategoria.Text = Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Descripcion_Categoria"].Value);
                txtStock_Actual.Text = Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Stock_Actual"].Value);
            }
        }
        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 1;  //Nuevo registro
            this.vCodigoProducto = 0;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar que los datos esten correctos
            if (txtDescripcion_Producto.Text == string.Empty || txtMarca_Producto.Text == string.Empty ||
                cmbMedidas.Text == string.Empty || cmbCategoria.Text == string.Empty || 
                txtStock_Actual.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar todos los datos requeridos (*)",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else //Procedo a guardar la informacion
            {
                string respuesta = "";
                
                E_Productos oProp = new E_Productos();
                oProp.Codigo_Producto = this.vCodigoProducto;

                oProp.Descripcion_Producto = txtDescripcion_Producto.Text;
                oProp.Marca_Producto = txtMarca_Producto.Text;
                oProp.Codigo_Medida = Convert.ToInt32(cmbMedidas.SelectedValue);
                oProp.Codigo_Categoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                oProp.Stock_Actual = Convert.ToDecimal(txtStock_Actual.Text);

                D_Productos Datos = new D_Productos();
                respuesta = Datos.Guardar_Producto(this.nEstadoGuarda, oProp);

                if(respuesta == "OK")
                {
                    this.ListadoProducto("%");
                    MessageBox.Show("Los datos han sido guardados correctamente",
                                    "Aviso de sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    this.vCodigoProducto = 0;
                    this.LimpiaTexto();
                    this.EstadoTexto(false);
                    this.EstadoBotones(true);
                }
            }
        }

        private void dgvListado_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionaItemProducto();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 2;  //Actualizar registro significa el estado 2

            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_Producto.Select();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ListadoProducto(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado_Productos.Rows.Count <= 0 ||
                string.IsNullOrEmpty(Convert.ToString(dgvListado_Productos.CurrentRow.Cells["Codigo_Producto"].Value)))
             {
                MessageBox.Show("No se tiene informacion para eliminar",
                                "Aviso del sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                string respuesta = "";

                D_Productos Datos = new D_Productos();
                respuesta = Datos.Activo_Producto(this.vCodigoProducto, false);

                if (respuesta == "OK")
                {
                    this.ListadoProducto("%");
                    this.LimpiaTexto();
                    vCodigoProducto = 0;

                    MessageBox.Show("El registro seleccionado ha sido eliminado",
                                    "Aviso del sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }
    }
}