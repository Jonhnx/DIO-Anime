using System;

namespace DIO.Series
{
    class Program
    {
        static AnimeRepositorio Repositorio = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnime();
                        break;
                    case "3":
                        AtualizarAnime();
                        break;
                    case "4":
                        ExcluirAnime();
                        break;
                    case "5":
                        VisualizarAnime();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma das opções disponiveis por favor.");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarAnimes()
        {
            var Lista = Repositorio.Lista();
            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhum Anime Cadastrado");
                return;
            }
            Console.WriteLine("Listar anime por: ");
            System.Console.WriteLine("1-> Todos");
            System.Console.WriteLine("2-> Gênero");
            string opcao = Console.ReadLine().ToUpper();
            switch(opcao){
                case "1":
                foreach(var anime in Lista)
                {
                    if(anime.Excluido == true)
                    {
                        Console.WriteLine($"#ID {anime.Id}: - {anime.Titulo} : *Excluido*");
                    }
                    else
                    {
                        Console.WriteLine($"#ID {anime.Id}: - {anime.Titulo}");
                    }
                }
                break;
                case "2":
                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int generoAnime = int.Parse(Console.ReadLine());
                foreach(var anime in Lista)
                {
                    if(anime.Genero == (Genero)generoAnime)
                    {
                        if(anime.Excluido == true)
                        {
                            Console.WriteLine($"#ID {anime.Id}: - {anime.Titulo} : *Excluido*");
                        }
                        else
                        {
                            Console.WriteLine($"#ID {anime.Id}: - {anime.Titulo}");
                        }
                    }
                }
                break;
            }
        }


        private static void InserirAnime()
        {
            Console.WriteLine("Inserir novo Anime");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int generoAnime = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o Titulo do Anime: ");
            string tituloAnime = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento do Anime: ");
            int lancamentoAnime = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Anime: ");
            string descricaoAnime = Console.ReadLine();

            Anime novoAnime = new Anime(Repositorio.ProximoId(), (Genero)generoAnime, 
                                        tituloAnime, descricaoAnime, lancamentoAnime);
            Repositorio.Insere(novoAnime);
        }        
        private static void AtualizarAnime()
        {
            Console.WriteLine("Digite o ID do Anime: ");
            int idAnime = int.Parse(Console.ReadLine());

            var Lista = Repositorio.Lista();

            if(Lista[idAnime].Excluido == true)
            {
                Console.WriteLine("Anime atualmente excluido,"
                                   + "gostaria de inserir este título novamente (S ou N)? ");
                char s = char.Parse(Console.ReadLine().ToUpper());
                if(s == 'S')
                {
                    Lista[idAnime].Restaurar();
                }
            }
            else
            {
                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int generoAnime = int.Parse(Console.ReadLine());
            
                Console.Write("Digite o Titulo do Anime: ");
                string tituloAnime = Console.ReadLine();

                Console.Write("Digite o Ano de Lançamento do Anime: ");
                int lancamentoAnime = int.Parse(Console.ReadLine());

                Console.Write("Digite a Descrição do Anime: ");
                string descricaoAnime = Console.ReadLine();

                Anime atualizaAnime = new Anime(idAnime, (Genero)generoAnime, 
                                                tituloAnime, descricaoAnime, lancamentoAnime);
                Repositorio.Atualiza(idAnime, atualizaAnime);
            }
        }

        private static void ExcluirAnime()
        {
            Console.WriteLine("Digite o id do Anime: ");
            int idAnime = int.Parse(Console.ReadLine());
            var Lista = Repositorio.Lista();
            Console.WriteLine($"Deseja mesmo excluir este Anime: {Lista[idAnime].Titulo} ?");
            char confirmacao = char.Parse(Console.ReadLine().ToUpper());
            if(confirmacao == 'S')
                Repositorio.Exclui(idAnime);
            else
                return;
        }

        private static void VisualizarAnime()
        {
            Console.WriteLine("Digite o id do Anime: ");
            int idAnime = int.Parse(Console.ReadLine());

            var Anime = Repositorio.RetornaPorId(idAnime);

            if(Anime.Excluido == false)
                Console.WriteLine(Anime);
            else
                Console.WriteLine("Anime Excluido! Para restaurar este titulo, favor acessar a opção Atualizar Anime!");
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Animes ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1-> Listar Animes");
            Console.WriteLine("2-> Inserir Novo Anime");
            Console.WriteLine("3-> Atualizar Anime");
            Console.WriteLine("4-> Excluir Anime");
            Console.WriteLine("5-> Visualizar Anime");
            Console.WriteLine("C-> limpar tela");
            Console.WriteLine("X-> Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
