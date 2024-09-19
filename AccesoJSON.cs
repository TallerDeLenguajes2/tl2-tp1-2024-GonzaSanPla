namespace EspacioAccesoJSON;

using EspacioCadeteria;
using EspacioCadete;
using EspacioAccesoADatos;
using System.Text.Json;
using System.Text.Json.Serialization;

class  AccesoJSON: AccesoADatos
{
    public AccesoJSON()
    {
        
    }
    public override void cargarCadeteria(string path, Cadeteria cadeteria)
    {
        if(existeArchivo(path))
        {
            string documento;
            using (var archivoOpen = new FileStream(path, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            cadeteria=JsonSerializer.Deserialize<Cadeteria>(documento);
        }else
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("No se encontro el archivo");
        }
    }

    public override void cargarCadetes(string path, Cadeteria cadeteria)
    {
        if(existeArchivo(path))
        {
            string documento;
            using (var archivoOpen = new FileStream(path, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            cadeteria.ListadoCadetes=JsonSerializer.Deserialize<List<Cadete>>(documento);
        }else
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("No se encontro el archivo");
        }
    }

    

}