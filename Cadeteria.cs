namespace EspacioCadeteria;

using System.Data.Common;
using EspacioCadete;
using EspacioPedido;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes= new List<Cadete>(); 
    private List<Pedido> pedidosNoAsignados = new List<Pedido>();
    private int contPedidos=0;


    public Cadeteria()
    {

    }

    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }
    public void DarDeAltaPedidos()
    {
        Pedido nuevoPedido= new Pedido(contPedidos);
        contPedidos++;
        pedidosNoAsignados.Add(nuevoPedido);

    }

    public void AsignarPedido()
    {
        int idCadete,idPedido;
        string idCadeteS,idPedidoS;
        Console.ForegroundColor=ConsoleColor.DarkBlue;
        Console.WriteLine("\n ----------Lista de cadetes de "+Nombre+"----------");
        foreach(Cadete cadete in ListadoCadetes)
        {
            cadete.MostarCadete();
        }

        Console.WriteLine("\nIngrese el id del cadete al que le quiere asignar el pedido:");
        int.TryParse(Console.ReadLine(), out idCadete);


        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.WriteLine("\n ----------Lista de pedidos pendientes----------");
        foreach(Pedido pedido in pedidosNoAsignados)
        {
            pedido.MostrarPedido();
        }

        Console.WriteLine("\nIngrese el id del pedido :");
        int.TryParse(Console.ReadLine(), out idPedido);
        Cadete cadeteElegido= ListadoCadetes.FirstOrDefault(Cadete=>Cadete.Id==idCadete);  // Te tira el primero que encuentra o null si no los encuentra 
        Pedido pedidoElegido= pedidosNoAsignados.FirstOrDefault(Pedido=>Pedido.NumPedido==idPedido);
      
        if(cadeteElegido != null)
        {
            if(pedidoElegido != null)
            {
                cadeteElegido.AgregarPedido(pedidoElegido);
                pedidosNoAsignados.Remove(pedidoElegido);
            }else
            {
                Console.ForegroundColor=ConsoleColor.DarkRed;
                Console.WriteLine("No se encontro el pedido");
            }
        }else
        {
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine("No se encontro el cadete");
        }
    }

    public void CambiarEstado(int NumPedido)
    {
        foreach (Cadete cadete in ListadoCadetes)
        {
            Pedido pedidoElegido= cadete.ListadoPedidos.FirstOrDefault(Pedido=>Pedido.NumPedido==NumPedido);
            if(pedidoElegido!= null)
            {
                pedidoElegido.CambiarEstado();
            }
        }
    }
    public void cambiarCadeteDelPedido(int numPedido, int numCadeteNuevo)
    {
        Pedido pedido=null;
        foreach (Cadete cadete in ListadoCadetes)
        {
            if(pedido==null)
            {
                pedido=cadete.QuitarPedido(numPedido);
            }
        }
  
        Cadete cadeteElegio=ListadoCadetes.FirstOrDefault(cadete=>cadete.Id==numCadeteNuevo);
        if(pedido!=null)
        {
            cadeteElegio.AgregarPedido(pedido);
        }else
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("NO SE ENCOTRO EL PEDIDO");
        }
    }
    public void MostarMontoTotal()
    {
        int total=0;
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        Console.WriteLine("\n ----------Monto total por cadete ----------");
        foreach(Cadete cadete in ListadoCadetes)
        {
            total+=cadete.MontoTotal();
            Console.WriteLine("\n\nNombre:"+cadete.Nombre+"\nId:"+cadete.Id+"Monto total:"+cadete.MontoTotal);

        }
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        Console.WriteLine("\n ----------Monto total del dia ----------");
        Console.WriteLine("\nTotak:"+total);

    }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
} 
