using CRUDDatatableAjax.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDDatatableAjax.Data
{
    public class DataContact
    {
        //Obtener la lista de todos los contactos que han sido registrados en nuestra tabla de contacto
        public List<Contacto> ContactList() {

            var Listacontactos = new List<Contacto>(); //creamos una lista de contacto

            var conn = new Connection(); //Conectamos con la bd

            using (var connection = new SqlConnection(conn.GetDefaultConnection())){ //Cadena para crear la conexion

                connection.Open(); //Abrimos la conexion
                SqlCommand cmd = new SqlCommand("SP_Listar", connection); //param 1: proced_almac, param2: conexión
                cmd.CommandType = CommandType.StoredProcedure; //decimos que es de tipo procedimiento almacenado

                using (var i = cmd.ExecuteReader()){
                    
                    while (i.Read()){// leo cada uno de los registros de SP_Listar

                        Listacontactos.Add(new Contacto() { 
                            Id =  Convert.ToInt32(i["Id"]),
                            Name = i["Name"].ToString(),
                            Phone = i["Phone"].ToString(),
                            Email = i["Email"].ToString(),
                        });
                    }
                }
            }
            
            return Listacontactos;
        }


        public Contacto GetContactById(int id)
        {

            var contactById = new Contacto(); //creamos una lista de contacto

            var conn = new Connection(); //Conectamos con la bd

            using (var connection = new SqlConnection(conn.GetDefaultConnection())) 
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("SP_Obtener", connection); //param 1: proced_almac, param2: conexión
                cmd.Parameters.AddWithValue("Id", id);
                cmd.CommandType = CommandType.StoredProcedure; //decimos que es de tipo procedimiento almacenado

                using (var i = cmd.ExecuteReader())
                {

                    while (i.Read())
                    {// leo cada uno de los registros de SP_Listar

                        contactById.Id = Convert.ToInt32(i["Id"]);
                        contactById.Name = i["Name"].ToString();
                        contactById.Phone = i["Phone"].ToString();
                        contactById.Email = i["Email"].ToString();
                    }
                }
            }

            return contactById;
        }

        public bool Create(Contacto contacto)
        {
            bool resp;

            try
            {
                var conn = new Connection(); //Conectamos con la bd

                using (var connection = new SqlConnection(conn.GetDefaultConnection()))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_Guardar", connection); //param 1: proced_almac, param2: conexión
                    cmd.Parameters.AddWithValue("Name", contacto.Name);
                    cmd.Parameters.AddWithValue("Phone", contacto.Phone);
                    cmd.Parameters.AddWithValue("Email", contacto.Email);
                    cmd.CommandType = CommandType.StoredProcedure; //decimos que es de tipo procedimiento almacenado
                    cmd.ExecuteNonQuery(); //Ejecuto el procedimiento alamacenado
                }
                resp = true;
            }
            catch (Exception ex)
            {   
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }


        public bool Update(Contacto contacto)
        {
            bool resp;

            try
            {
                var conn = new Connection(); //Conectamos con la bd

                using (var connection = new SqlConnection(conn.GetDefaultConnection()))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_Editar", connection); //param 1: proced_almac, param2: conexión
                    cmd.Parameters.AddWithValue("Id", contacto.Id);
                    cmd.Parameters.AddWithValue("Name", contacto.Name);
                    cmd.Parameters.AddWithValue("Phone", contacto.Phone);
                    cmd.Parameters.AddWithValue("Email", contacto.Email);
                    cmd.CommandType = CommandType.StoredProcedure; //decimos que es de tipo procedimiento almacenado
                    cmd.ExecuteNonQuery(); //Ejecuto el procedimiento alamacenado
                }
                resp = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }


        public bool Delete(int id)
        {
            bool resp;

            try
            {
                var conn = new Connection(); //Conectamos con la bd

                using (var connection = new SqlConnection(conn.GetDefaultConnection()))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_Eliminar", connection); //param 1: proced_almac, param2: conexión
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.CommandType = CommandType.StoredProcedure; //decimos que es de tipo procedimiento almacenado
                    cmd.ExecuteNonQuery(); //Ejecuto el procedimiento alamacenado
                }
                resp = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                resp = false;
            }

            return resp;
        }
    }
}
