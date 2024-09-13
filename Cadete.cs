namespace EspacioCadete;

using EspacioPedido;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos= new List<Pedido>();


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

    public void AgregarPedido(Pedido NuevoPedido)
    {
        ListadoPedidos.Add(NuevoPedido);
    }
    public void MostrarPedidos()
    {
        Console.WriteLine(ListadoPedidos);
        if(ListadoPedidos.Count.Equals(0))
        {
             Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine("\n"+Nombre+" no tiene ningun pedido");
        }else
        {
             Console.ForegroundColor=ConsoleColor.DarkGreen;
            Console.WriteLine("\n ----------Lista de pedidos de "+Nombre+"----------");
            foreach (Pedido pedido in ListadoPedidos)
            {
                pedido.MostrarPedido();
            }
        }
    }

    public void MostarCadete()
    {
        Console.ForegroundColor=ConsoleColor.DarkBlue;
        Console.WriteLine("\n\nId:"+Id+"\nNombre:"+Nombre);
    }

    public Pedido QuitarPedido(int numPedidoQuitar)
    {
        Pedido pedidoElegido= ListadoPedidos.FirstOrDefault(Pedido=>Pedido.NumPedido==numPedidoQuitar);

        ListadoPedidos.Remove(pedidoElegido);
        return pedidoElegido;
    }
    public int MontoTotal()
    {
        return ListadoPedidos.Count()*500;
    }
    public int CantidadPedidos()
    {
        return listadoPedidos.Count();
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Id { get => id; set => id = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
}