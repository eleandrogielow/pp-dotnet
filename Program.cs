using System;

namespace Dio.Series
{
        class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            var serie = repositorio.RetornarPorId(indiceSerie);


            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine()!);

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine()!;

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine()!;

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualizar(indiceSerie, atualizarSerie);
        }

        private static void ListarSeries()
            {
                Console.WriteLine("Listar séries");

                var lista = repositorio.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }

                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }
            }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserie nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine()!;

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine()!;

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo : entradaTitulo,
                                            ano : entradaAno,
                                            descricao : entradaDescricao);
            
            repositorio.Insere(novaSerie);

        }
        

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Vizualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine()!.ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;
        }
    }
}