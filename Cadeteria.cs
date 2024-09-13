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
    private List<Pedido> pedidosAsignados = new List<Pedido>();

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
                // cadeteElegido.AgregarPedido(pedidoElegido);
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
            // Pedido pedidoElegido= cadete.ListadoPedidos.FirstOrDefault(Pedido=>Pedido.NumPedido==NumPedido);
            // if(pedidoElegido!= null)
            // {
            //     pedidoElegido.CambiarEstado();
            // }
        }
    }
    public void MostarMontoTotal()
    {
        
        int total=0, contadorPedidos=0,cantCadetes=0;
        float promedioEnvios=0;
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        Console.WriteLine("\n ----------Informacion  por cadete ----------");
        foreach(Cadete cadete in ListadoCadetes)
        {
            // total+=cadete.MontoTotal();
            // contadorPedidos+=cadete.CantidadPedidos();
            // Console.WriteLine("\n\nNombre:"+cadete.Nombre+"\nId:"+cadete.Id+"\nMonto total:"+cadete.MontoTotal()+"\nCantidad de pedidos:"+cadete.CantidadPedidos());

        }
        cantCadetes=listadoCadetes.Count;
        promedioEnvios=(float)contadorPedidos/cantCadetes;
        Console.ForegroundColor=ConsoleColor.DarkYellow;
        Console.WriteLine("\n ----------Total del dia ----------");
        Console.WriteLine("\nMonto total:"+total);
        Console.WriteLine("\nCantidad de envios:"+contadorPedidos);
        Console.WriteLine("\nPromedio de envios por cadete:"+promedioEnvios);



    }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
} 
