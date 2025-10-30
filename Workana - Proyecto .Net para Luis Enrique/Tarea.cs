namespace Workana___Proyecto_.Net_para_Luis_Enrique
{
    internal class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Completada { get; set; }

        public Tarea(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
            Completada = false;
        }

        public void MarcarComoCompletada()
        {
            Completada = true;
        }

        public override string ToString()
        {
            string estado = Completada ? "[OK]" : "[PENDIENTE]";
            return $"[{Id}] {Titulo} - {estado}";
        }
    }
}
