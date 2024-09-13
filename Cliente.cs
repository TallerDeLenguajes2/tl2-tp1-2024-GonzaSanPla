
using System.Linq;
namespace EspacioCliente;

public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDirección;

    public Cliente()
    {

        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("\n ----------Carga de datos del cliente----------");

        Console.ForegroundColor=ConsoleColor.Gray;
        Console.WriteLine("\nIngrese los datos del cliente");
        
        Console.WriteLine("\n -Nombre:");
        Nombre=Console.ReadLine();
        Console.WriteLine("\n -Direccion:");
        direccion=Console.ReadLine();
        Console.WriteLine("\n Telefono:");
        telefono=Console.ReadLine();
        Console.WriteLine("\n Datos adicionales de la direccion:");
        datosReferenciaDirección=Console.ReadLine();
    }


    public void CargarCliente()
    {

    }
    public void MostrarCliente()
    {
        Console.WriteLine("\nNombre: "+Nombre+"\nDireccion: "+direccion+"\nTelefono: "+telefono+"\nDatos de la dirección: "+DatosReferenciaDirección);
    }

    public void MostrarDireccion()
    {
        Console.WriteLine("\nDireccion de ",Nombre,": ", direccion);
    }


    public global::System.String Direccion { get => direccion; set => direccion = value; }
    public global::System.String Telefono { get => telefono; set => telefono = value; }
    public global::System.String DatosReferenciaDirección { get => datosReferenciaDirección; set => datosReferenciaDirección = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}

