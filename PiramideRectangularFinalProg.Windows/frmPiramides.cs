using PiramideRectangularFinalProg.Datos;
using PiramideRectangularFinalProg.Entidades;

namespace PiramideRectangularFinalProg.Windows
{
    public partial class frmPiramides : Form
    {

        private RepositorioPiramidesRectangulares repositorio;
        private List<PiramideRectangular> piramides;

        public frmPiramides()
        {
            InitializeComponent();
            repositorio = new RepositorioPiramidesRectangulares();
        }

        private void frmPiramides_Load(object sender, EventArgs e)
        {
            piramides = repositorio.ObtenerLista();

            if (piramides.Count == 0) MessageBox.Show("¡No hay piramides!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {

            foreach (var piramide in piramides)
            {
                var row = ConstruirFila(dgvDatos);
                EstablecerLinea(row, piramide);
                AgregarLinea(row, dgvDatos);
            }

            MostrarCantidadPiramides();
        }

        private DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dgv);
            return row;
        }

        private void EstablecerLinea(DataGridViewRow row, PiramideRectangular obj)
        {
            row.Cells[colLado.Index].Value = obj.LadoBase;
            row.Cells[colCantidad.Index].Value = obj.CantidadLados;
            row.Cells[colMaterial.Index].Value = obj.Material;
            row.Cells[colColor.Index].Value = obj.Color.ToString();
            row.Cells[colVolumen.Index].Value = obj.CalcularVolumen().ToString("N2");

            row.Tag = obj;
        }

        private void AgregarLinea(DataGridViewRow row, DataGridView dgv)
        {
            dgv.Rows.Add(row);
        }

        private void MostrarCantidadPiramides()
        {
            txtCantidad.Text = repositorio.ObtenerCantidad().ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPiramideAE form = new frmPiramideAE() { Text = "Agregar Piramide" };
            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            PiramideRectangular piramide = form.ObtenerPiramide();
            if (!repositorio.Existe(piramide))
            {

                repositorio.Agregar(piramide);
                piramides = repositorio.ObtenerLista();

                MessageBox.Show($"¡Piramide agregada!\n{piramide.ToString()}", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosEnGrilla();

            }
            else
            {
                MessageBox.Show("¡Esta piramide ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("¿Estas seguro de esto?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            var pBorrar = dgvDatos.SelectedRows[0];
            var piramide = pBorrar.Tag as PiramideRectangular;

            repositorio.Eliminar(piramide);
            piramides = repositorio.ObtenerLista();

            MessageBox.Show("¡Piramide eliminada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MostrarDatosEnGrilla();

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {

            piramides = repositorio.ObtenerLista();
            MostrarDatosEnGrilla();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {

            var pDetalles = dgvDatos.SelectedRows[0];
            var piramide = pDetalles.Tag as PiramideRectangular;

            frmDetallePiramide form = new frmDetallePiramide() { Text = "Detalles de la Piramide." };
            form.EstablecerPiramide(piramide);
            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.OK) return;

        }
    }
}
