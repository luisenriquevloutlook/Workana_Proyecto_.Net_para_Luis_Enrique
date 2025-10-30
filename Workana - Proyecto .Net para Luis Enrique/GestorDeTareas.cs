using System.Text.Json;

namespace Workana___Proyecto_.Net_para_Luis_Enrique
{
    internal class GestorDeTareas
    {
        private List<Tarea> tareas = new List<Tarea>();
        private int contadorId = 1;

        public void AgregarTarea(string titulo)
        {
            var nuevaTarea = new Tarea(contadorId++, titulo);
            tareas.Add(nuevaTarea);
            Console.WriteLine(">>> Tarea agregada correctamente. <<<");
        }

        public void ListarTareas()
        {
            if (!tareas.Any())
            {
                Console.WriteLine("!!! No hay tareas registradas. !!!");
                return;
            }

            Console.WriteLine("\nLista de tareas: ");
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea);
            }
        }

        public void MarcarComoCompletada(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.MarcarComoCompletada();
                Console.WriteLine(">>> Tarea marcada como completada. <<<");
            }
            else
            {
                Console.WriteLine("!!! Tarea no encontrada. !!!");
            }
        }

        public void EliminarTarea(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                Console.WriteLine("[- - - Tarea eliminada. - - -]");
            }
            else
            {
                Console.WriteLine("!!! Tarea no encontrada. !!!");
            }
        }

        public void GuardarEnArchivoJson(string ruta)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tareas, opciones);
            File.WriteAllText(ruta, json);
            Console.WriteLine("Tareas [[ GUARDADAS ]] en archivo JSON. \nPresione una tecla para salir...");
            Console.ReadKey();
        }

        public void CargarDesdeArchivoJson(string ruta)
        {
            if (!File.Exists(ruta)) return;

            string json = File.ReadAllText(ruta);
            var tareasCargadas = JsonSerializer.Deserialize<List<Tarea>>(json);
            if (tareasCargadas != null)
            {
                tareas = tareasCargadas;
                contadorId = tareas.Max(t => t.Id) + 1;
                Console.WriteLine("[[ CARGANDO ARCHIVO... ]] Tareas importadas desde archivo JSON.");
            }
        }
    }
}
