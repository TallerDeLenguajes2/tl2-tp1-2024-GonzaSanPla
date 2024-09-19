
namespace EspacioPedido;

using System.Runtime.CompilerServices;
using EspacioCadete;
using EspacioCliente;
using EspacioPedido;
public class Pedido
{
    private int  numPedido;
    private string observacion;
    private Cliente clientePedido;
    private Estado estado;

    private Cadete cadete;
    public enum Estado
    {
        Preparado,
        Entregado
    }

    
    public Pedido()
    {

    }
    public  Pedido(int numPedidoIng, Cliente clienteIng,string observacionIng) //Ing=Ingresado
    {
        NumPedido=numPedidoIng;
        clientePedido= clienteIng;
        estado= Estado.Preparado;
       
        observacion=Console.ReadLine();   
    }

    public void AsignarCadete(Cadete cadete)
    {
        this.Cadete=cadete;
    }
    public void MostarDireccionCliente()
    {
        ClientePedido.MostrarDireccion();
    }
    public void MostrarCliente()
    {
        ClientePedido.MostrarCliente();
    }

    public void MostrarPedido()
    {
        Console.ForegroundColor=ConsoleColor.DarkGreen;
        Console.WriteLine("\n\nNuemro de pedido:"+NumPedido+"\nNombre del cliente:"+clientePedido.Nombre);
    }
    
    public void CambiarEstado()
    {
        estado=Estado.Entregado;
    }
   
    public global::System.String Observacion { get => observacion; set => observacion = value; }
    public Cliente ClientePedido { get => clientePedido; set => clientePedido = value; }
    public int NumPedido { get => numPedido; set => numPedido = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }
}