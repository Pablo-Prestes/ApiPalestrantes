namespace DevEvents.API.Entities
{
    public class DevEvent
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public List<DevEventsPalestrantes> Palestrantes { get; set; }

        public bool  Deletado { get; set; }

        public DevEvent() 
        {
            Palestrantes = new List<DevEventsPalestrantes>();
            Deletado = false;
        }

        public void Update(string titulo, string descricao, DateTime dataInicio, DateTime dataFim) 
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;  
            DataFim = dataFim;
        }
        public void Delete() 
        {
            Deletado = true;
        }
    }
}
