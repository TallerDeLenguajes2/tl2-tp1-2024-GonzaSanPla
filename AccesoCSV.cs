namespace EspacioAccesoCSV;

using EspacioCadeteria;
using EspacioCadete;
using EspacioAccesoADatos;
class  AccesoCSV: AccesoADatos
{
    public AccesoCSV()
    {}
    public override void cargarCadeteria(string path, Cadeteria cadeteria)
    {
        if(existeArchivo(path))
        {
            StreamReader x = new StreamReader(path); //Levanto el archivo csv
            string lineas= x.ReadLine(); //en esta linea se lee una linea de un arhivo, y comienzo con la primera linea del csv
            string [] campos = lineas.Split(','); //lineas.Split(',') devuelve un arreglo cuyos campos son cada elemento entre comas
            cadeteria.Nombre = campos[0];
            cadeteria.Telefono = campos[1];
        }
    }

    public override void cargarCadetes(string path, Cadeteria cadeteria)
    {
        if(existeArchivo(path))
        {
            StreamReader x = new StreamReader(path); //Levanto el archivo csv
            string lineas= x.ReadLine(); //en esta linea se lee una linea de un arhivo, y comienzo con la primera linea del csv
            while(lineas != null)//Con el while voy iterando linea por linea hasta que llegue a una vacia
            {
                Cadete cadete = new Cadete();
                string [] campos = lineas.Split(','); //lineas.Split(',') devuelve un arreglo cuyos campos son cada elemento entre comas
                int.TryParse(campos[0], out int id);
                cadete.Id = id;
                cadete.Nombre = campos[1];
                cadete.Direccion = campos[2];
                cadete.Telefono = campos[3];
                cadeteria.agregarCadete(cadete);
                lineas = x.ReadLine();
            }
        }
    }

    

}