
namespace EspacioPedido;
using EspacioCliente;

public class Pedido()
{
    private string numPedido;
    private string observacion;
    private Cliente cliente;
    private string estado;

    public Pedido()
    {

    }


    public global::System.String NumPedido { get => numPedido; set => numPedido = value; }
    public global::System.String Observacion { get => observacion; set => observacion = value; }
    public global::System.String Estado { get => estado; set => estado = value; }
}