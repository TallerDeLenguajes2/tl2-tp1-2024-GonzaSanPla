
using EspacioCadete;
using EspacioCliente;
using EspacioPedido;
using EspacioAccesoADatos;
using EspacioAccesoCSV;
using EspacioAccesoJSON;
using EspacioCadeteria;

Cadeteria miCadeteria= new Cadeteria();
string opcion="0";
miCadeteria=CargarDatos();

do
{
    opcion=ElegirOpcionCadeteria();
    switch(opcion)
    {
        case "1":
            miCadeteria.DarDeAltaPedidos();
            break;
        case "2":
            miCadeteria=AsignarPedido(miCadeteria);
            break;
        case "3":
            miCadeteria=cambiarEstadoPedido(miCadeteria);
            break;
        case "4":
            miCadeteria=cambiarCadeteDelPedido(miCadeteria);
            break;
    }
}while(opcion!="5");

Informe(miCadeteria);

static Cadeteria CargarDatos()
{
    Cadeteria cadeteria=new Cadeteria();
    string pathCadetria="",pathCadetes="";

    string carga=ElegirOpcionCargaDatos();
    switch (carga)
    {
        case"1":
            AccesoCSV datosCSV = new AccesoCSV();    
            pathCadetria="cadeteria.csv";
            pathCadetes="cadetes.csv";
            datosCSV.cargarCadeteria(pathCadetria,cadeteria);
            datosCSV.cargarCadetes(pathCadetes,cadeteria);

            break;
        case"2":
            AccesoJSON datosjSON = new AccesoJSON();    
            pathCadetria="cadeteria.json";
            pathCadetes="cadetes.json";
            datosjSON.cargarCadeteria(pathCadetria,cadeteria);
            datosjSON.cargarCadetes(pathCadetes,cadeteria);
            break;
    }

    return cadeteria;
}
static string ElegirOpcionCargaDatos()
{
    string opcion;
        do
        {
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine("------------Elija la forma de cargar datos------------");
            Console.WriteLine("1-Mendiante CSV");
            Console.WriteLine("2-Mendiante JSON");
            opcion=Console.ReadLine();
        }while(opcion!="1"&&opcion!="2");

        return opcion;
}


static string ElegirOpcionCadeteria()
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
static Cadeteria AsignarPedido(Cadeteria cadeteria)
{
        int idCadete,idPedido;
        string idCadeteS,idPedidoS;
        Console.ForegroundColor=ConsoleColor.DarkBlue;
        // Console.WriteLine("\n ----------Lista de cadetes de "+Nombre+"----------");
        // foreach(Cadete cadete in ListadoCadetes)
        // {
        //     cadete.MostarCadete();
        // }

        Console.WriteLine("\nIngrese el id del cadete al que le quiere asignar el pedido:");
        int.TryParse(Console.ReadLine(), out idCadete);


        Console.ForegroundColor=ConsoleColor.DarkGreen;
        // Console.WriteLine("\n ----------Lista de pedidos pendientes----------");
        // foreach(Pedido pedido in pedidosNoAsignados)
        // {
        //     pedido.MostrarPedido();
        // }

        Console.WriteLine("\nIngrese el id del pedido :");
        int.TryParse(Console.ReadLine(), out idPedido);



        cadeteria.AsignarPedido(idCadete,idPedido);
      
        //Mostrar mensaje de error por si ingresa un id de cadete o de pedido mal!!!!!

        // if(cadeteElegido != null)
        // {
        //     if(pedidoElegido != null)
        //     {
        //         pedidoElegido.AsignarCadete(cadeteElegido);
        //         pedidosNoAsignados.Remove(pedidoElegido);
        //     }else
        //     {
        //         Console.ForegroundColor=ConsoleColor.DarkRed;
        //         Console.WriteLine("No se encontro el pedido");
        //     }
        // }else
        // {
        //     Console.ForegroundColor=ConsoleColor.DarkRed;
        //     Console.WriteLine("No se encontro el cadete");
        // }
    return cadeteria;
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

    cadeteria.cambiarCadeteDelPedido(opcionEmpleado,opcionPedido);

    return cadeteria;
}

static void Informe(Cadeteria miCadeteria)
{
    List<string> montosTotalesCadetes= new List<string>();
    string totalDia;

    Console.ForegroundColor=ConsoleColor.DarkYellow;
    Console.WriteLine("\n ----------Informacion  por cadete ----------");

    montosTotalesCadetes=miCadeteria.MostarMontoTotalCadetes();
    foreach (string montoCadete in montosTotalesCadetes)
    {
        Console.WriteLine(montoCadete);
    }
    Console.WriteLine("\n ----------Total del dia ----------");
    totalDia=miCadeteria.MostarMontoTotalCadeteria();
    Console.WriteLine(totalDia);
}
