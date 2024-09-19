namespace EspacioCadeteria;

using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
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

    private int total=0;
    public Cadeteria()
    {

    }

    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }
    public void DarDeAltaPedidos(Pedido nuevoPedido)
    {
        ContPedidos++;
        pedidosNoAsignados.Add(nuevoPedido);

    }

    public void AsignarPedido( int idCadete,int idPedido)
    {
        Cadete cadeteElegido= ListadoCadetes.FirstOrDefault(Cadete=>Cadete.Id==idCadete);  // Te tira el primero que encuentra o null si no los encuentra 
        Pedido pedidoElegido= pedidosNoAsignados.FirstOrDefault(Pedido=>Pedido.NumPedido==idPedido);
      
        if(cadeteElegido != null)
        {
            if(pedidoElegido != null)
            {
                pedidoElegido.AsignarCadete(cadeteElegido);
                pedidosAsignados.Add(pedidoElegido);
                pedidosNoAsignados.Remove(pedidoElegido);
            }
        }
    }
    public void CambiarEstado(int NumPedido)
    {
        foreach (Cadete cadete in ListadoCadetes)
        {
            Pedido pedidoElegido= pedidosAsignados.FirstOrDefault(Pedido=>Pedido.NumPedido==NumPedido);
            if(pedidoElegido!= null)
            {
                pedidoElegido.CambiarEstado();
            }
        }
    }
    public void cambiarCadeteDelPedido(int idCadete,int idPedido)
    {
        Cadete cadeteElegido= ListadoCadetes.FirstOrDefault(Cadete=>Cadete.Id==idCadete);  // Te tira el primero que encuentra o null si no los encuentra 
        Pedido pedidoElegido= pedidosAsignados.FirstOrDefault(Pedido=>Pedido.NumPedido==idPedido);

        pedidoElegido.AsignarCadete(cadeteElegido);
    }
    
    public List<string> MostarMontoTotalCadetes()
    {
        List<string> montoTotalCadetes= new List<string>();
        foreach(Pedido pedido in pedidosAsignados)
        {
            pedido.Cadete.SumarPedido();
        }

        foreach(Cadete cadete in listadoCadetes)
        {
            montoTotalCadetes.Add("\n"+cadete.MostarCadeteInfo()+"\nMonto total:"+cadete.MontoTotal());
        }

        return montoTotalCadetes; 
    }
     public string MostarMontoTotalCadeteria()
    {
        float promedioEnvios;
        string montoDia;

        foreach(Cadete cadete in listadoCadetes)
        {
                total+=cadete.MontoTotal();
        }

        promedioEnvios=(float)pedidosAsignados.Count/listadoCadetes.Count;
 
        montoDia=("\nMonto total:"+total+"\nCantidad de envios:"+pedidosAsignados.Count+"\nPromedio de envios por cadete:"+promedioEnvios);

        return montoDia;
    }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public int ContPedidos { get => contPedidos; set => contPedidos = value; }
} 
