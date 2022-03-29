namespace CRUDDatatableAjax.Data
{
    public class Connection
    {
        private string DefaultConnection = string.Empty; //DefaultConnection está en appsetting.json
        public Connection(){
            //obtengo la cadena de conexion de appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //obtener la cadena de conexión de appsettings.json
            DefaultConnection = builder.GetSection("ConnectionStrings:DefaultConnection").Value; //GetSection pq quiero acceder a una sección especifica de este builder
            
        }
        //Obtenemos la cadena de manera simple (metodo get)
        public string GetDefaultConnection()
        {
            return DefaultConnection; //En el video es cadenaSQL
        }
    }
}
