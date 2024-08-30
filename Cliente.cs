
namespace EspacioCliente;
public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string DatosReferenciaDirección;

    public Cliente()
    {

    }

    public Cliente(string nombreIngrersado,string direccionIngresado,string telefonoIngresado,string DatosReferenciaDirecciónIngresado)
    {
        nombre=nombreIngrersado;
        direccion=direccionIngresado;
        telefono=telefonoIngresado;
        DatosReferenciaDirección=DatosReferenciaDirecciónIngresado;
    }

    public void MostrarCliente()
    {
        Console.WriteLine("\nNombre: "+nombre+"\nDireccion: "+direccion+"\nTelefono: "+telefono+"\nDatos de la dirección: "+DatosReferenciaDirección);
    }


    public global::System.String Nombre { get => nombre; set => nombre = value; }
    public global::System.String Direccion { get => direccion; set => direccion = value; }
    public global::System.String Telefono { get => telefono; set => telefono = value; }
    public global::System.String DatosReferenciaDirección1 { get => DatosReferenciaDirección; set => DatosReferenciaDirección = value; }
}