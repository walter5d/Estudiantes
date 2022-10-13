using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public class Estudiantes
    {
        ConexionBD conectar;
        private DataTable drop_estudiantes(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_estudiante as id,estudiante from estudiante;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_puesto(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige Puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_estudiantes();
            drop.DataTextField = "sangre";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_estudiantes() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_estudiantes as id,e.carnet,e.nombres,e.apellidos,e.direccion,e.telefono,e.correo_electronico,e.fecha_nacimiento,p.tipo_sangre,p.idtipo_sangre from estudiantes as e inner join estududiantes as p on e.id_tiposangre = p.id_tiposangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_estudiantes(GridView grid){
            grid.DataSource = grid_estudiantes();
            grid.DataBind();

        }
        public int agregar(string carnet,string nombres,string apellidos,string direccion,string telefono,string fecha,int id_tiposangre){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into estudiantes(carnet,nombres,apellidos,direccion,telefono,fecha_nacimiento,id_tiposangre) values('{0}','{1}','{2}','{3}','{4}','{5}',{6});",codigo,nombres,apellidos,direccion,telefono,fecha,id_puesto);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id,string carnet, string nombres, string apellidos, string direccion, string telefono, string fecha, int id_tiposangre){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update empleados set carnet = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}',id_estudiantes = {6} where id_tiposangre = {7};", carnet, nombres, apellidos, direccion, telefono, fecha, id_tiposangre,id);
            MySqlCommand modificar = new MySqlCommand(strConsulta, conectar.conectar);

            modificar.Connection = conectar.conectar;
            no_ingreso = modificar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }
        public int eliminar(int id){
            int no_ingreso = 0;
        conectar = new ConexionBD();
        conectar.AbrirConexion();
            string strConsulta = string.Format("delete from estudiantes  where id_estudiantes = {0};", id);
        MySqlCommand eliminar = new MySqlCommand(strConsulta, conectar.conectar);

            eliminar.Connection = conectar.conectar;
            no_ingreso = eliminar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;
        }

}
}