namespace EspacioCadete;

using EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    private int contPedidos=0;

    private int montoTotal=0;

    static int MONTOPORPEDIDO=500;
    public Cadete()
    {

    }
    public Cadete(int idIngresado)
    {
        Id=idIngresado;

        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("\n ----------Carga de datos del cadete----------");

        Console.ForegroundColor=ConsoleColor.Gray;
        Console.WriteLine("\nIngrese los datos del cadete");
        
        Console.WriteLine("\n -Nombre:");
        Nombre=Console.ReadLine();
        Console.WriteLine("\n -Direccion:");
        Direccion=Console.ReadLine();
        Console.WriteLine("\n Telefono:");
        Telefono=Console.ReadLine();
    }

    public string MostarCadeteInfo()
    {
        string infoCadete="\nId:"+Id+"\nNombre:"+Nombre;
        return(infoCadete);
    }

    public void SumarPedido()
    {
        contPedidos++;
    }

    public int MontoTotal()
    {
        for (int i = 0; i < contPedidos; i++)
        {
            montoTotal+=MONTOPORPEDIDO;
        }

        return montoTotal;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Id { get => id; set => id = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
}