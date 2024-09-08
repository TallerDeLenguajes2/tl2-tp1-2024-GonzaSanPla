
using EspacioCadete;
using EspacioCliente;
using EspacioPedido;
using EspacioManejoDatos;
using EspacioCadeteria;

ManejoDatos manejoDatos = new ManejoDatos();
Cadeteria miCadeteria= new Cadeteria();

string opcion = "3";

manejoDatos.cargarCadeteria("cadeteria.csv",miCadeteria);
manejoDatos.cargarCadetes("cadetes.csv",miCadeteria);


do
{
    opcion=ElegirOpcion();
    switch(opcion)
    {
        case "1":
            miCadeteria.DarDeAltaPedidos();
            break;
        case "2":
            miCadeteria.AsignarPedido();
            break;
        case "3":
            miCadeteria=cambiarEstadoPedido(miCadeteria);
            break;
        case "4":

            miCadeteria=cambiarCadeteDelPedido(miCadeteria);
            break;
    }
}while(opcion!="5");


static string ElegirOpcion()
{
    string opcion;
    do
    {
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("------------Elija una de las siguientes opciones------------");
        Console.WriteLine("1-Caragar un pedido");
        Console.WriteLine("2-Asignar un pedido a un cadete");
        Console.WriteLine("3-Cambiar estado de un pedido");
        Console.WriteLine("4-Reasignar pedido a otro cadete");
        Console.WriteLine("5-Terminar el dia");
        Console.WriteLine("Elegir opcion:");
        opcion=Console.ReadLine();
    }while(opcion!="1"&&opcion!="2"&&opcion!="3"&&opcion!="4"&&opcion!="5");

    return opcion;
}

static Cadeteria cambiarEstadoPedido(Cadeteria cadeteria)
{
    int opcionPedido,opcionEmpleado;
    Console.ForegroundColor=ConsoleColor.Gray;
    do
    {
        Console.WriteLine("Ingrese el numnero del pedido que quiere cambiar de estado:");
    }while(!int.TryParse(Console.ReadLine(),out opcionPedido));

    cadeteria.CambiarEstado(opcionPedido);

    return cadeteria;
}

static Cadeteria cambiarCadeteDelPedido(Cadeteria cadeteria)
{
    int opcionPedido,opcionEmpleado;
    Console.ForegroundColor=ConsoleColor.Gray;
    do
    {
        Console.WriteLine("Ingrese el numnero del pedido que quiere cambiar de cadete:");
    }while( !int.TryParse(Console.ReadLine(),out opcionPedido));
    do
    {
        Console.ForegroundColor=ConsoleColor.Gray;
        Console.WriteLine("Ingrese el numnero del cadete que quiera reasignar el pedido:");
    }while( !int.TryParse(Console.ReadLine(),out opcionEmpleado));

    cadeteria.cambiarCadeteDelPedido(opcionPedido,opcionEmpleado);

    return cadeteria;
}