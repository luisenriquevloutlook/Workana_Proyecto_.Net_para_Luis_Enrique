namespace Workana___Proyecto_.Net_para_Luis_Enrique
{
    class Program
    {
        static void Main(string[] args)
        {
            var gestor = new GestorDeTareas();
            bool salir = false;

            string rutaArchivo = "tareas.json";
            gestor.CargarDesdeArchivoJson(rutaArchivo);

            while (!salir)
            {
                Console.WriteLine("\n=== MENÚ DE TAREAS ===");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();
                        gestor.AgregarTarea(titulo);
                        break;

                    case "2":
                        Console.Clear();
                        gestor.ListarTareas();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        gestor.ListarTareas();
                        Console.Write("Ingrese el ID de la tarea a completar: ");
                        if (int.TryParse(Console.ReadLine(), out int idCompletar))
                            gestor.MarcarComoCompletada(idCompletar);
                        else
                            Console.WriteLine("*** ID inválido. ***");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        gestor.ListarTareas();
                        Console.Write("Ingrese el ID de la tarea a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                            gestor.EliminarTarea(idEliminar);
                        else
                            Console.WriteLine("*** ID inválido. ***");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "5":
                        string opcionSalir;
                        Console.WriteLine("!!! ¿Confirma que desea salir [S/N]? !!!");
                        opcionSalir = Console.ReadLine();
                        opcionSalir = opcionSalir.ToUpper();
                        if (opcionSalir == "S")
                        {
                            salir = true;
                            Console.WriteLine("<<< ¡Hasta pronto! >>>");
                            gestor.GuardarEnArchivoJson(rutaArchivo);
                        }
                        else
                        {
                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    default:
                        Console.WriteLine("*** Opción no válida. ***");
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
