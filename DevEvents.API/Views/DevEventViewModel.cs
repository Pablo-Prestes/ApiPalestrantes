using DevEvents.API.Entities;

namespace DevEvents.API.Views
{
    public class DevEventViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public List<DevEventPalestranteViewModel> Palestrantes { get; set; }

    }

    public class DevEventPalestranteViewModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? TituloPalestra { get; set; }
        public string? DescricaoPalestra { get; set; }
        public string? LinkedinPerfil { get; set; }

    }

}