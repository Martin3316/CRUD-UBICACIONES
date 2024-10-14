using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DAL;

namespace CrudUbicaciones_MALH
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicaionesDAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarUbicaciones();
            }
            
        }

        //Metodo encargado de listar los datos de la BD en un GRIDView
        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new ubicaionesDAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }

        //Metodo encargado de recolectar los datos de nuestra interfaz!
        public ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();

            //Recolectar datos de la capa de presentacion
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaionesDAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones(); //Para mostarlo en el GV
        }

        
        protected void gvUbicaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvUbicaciones.SelectedRow;

            txtID.Value = filaSeleccionada.Cells[1].Text;
            txtUbicacion.Text = filaSeleccionada.Cells[2].Text;
            txtLat.Text = filaSeleccionada.Cells[3].Text;
            txtLong.Text = filaSeleccionada.Cells[4].Text;

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;
        }

        //Modificar
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaionesDAL();
            bool success = oUbicacionesDAL.Modificar(datosUbicacion());

            if (success)
            {
                ListarUbicaciones();
                
            }
        }

        //Eliminar
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Value);
            oUbicacionesDAL = new ubicaionesDAL();
            bool success = oUbicacionesDAL.Eliminar(id);

            if (success)
            {
                ListarUbicaciones();
                
            }
        }
           //Limpiar
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Value = string.Empty;
            txtUbicacion.Text = string.Empty;
            txtLat.Text = string.Empty;
            txtLong.Text = string.Empty;

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            
        }
    }
}