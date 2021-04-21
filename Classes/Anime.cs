using System.Text;
namespace DIO.Series
{
    public class Anime : EntidadeBase
    {
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; private set; }

        public Anime(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            if(Excluido == false)
            {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Gênero: " + Genero);
            sb.AppendLine("Título: " + Titulo);
            sb.AppendLine("Descrição: " + Descricao);
            sb.AppendLine("Ano de Lançamento: " + Ano);
            return sb.ToString();
            }
            else
            {
                return "Anime Excluido.";
            }
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public void Restaurar()
        {
            Excluido = false;
        }

    }
}