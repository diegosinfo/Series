using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series.Classe;
using Series.Enum;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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
                        //VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        break;
                                           
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ExcluirSerie()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não existe series cadastradas ainda");
                return;
            }
            
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Confirma a exclusão do serie ID: {0} - {1} : (S/N) ?", indiceSerie, repositorio.RetornaPorId(indiceSerie).RetornaTitulo());


            string opcao;
            do
            {
                opcao = Console.ReadLine().ToUpper();

            } while (opcao != "N" && opcao != "S");

            if (opcao == "N") return;


            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            Serie atualizaSerie = CadastroDaSerie(indiceSerie);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            Serie novaSerie = CadastroDaSerie(repositorio.ProximoId());

            repositorio.Insere(novaSerie);
        }

        private static Serie CadastroDaSerie(int Id)
        {
            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: Id,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );

            return novaSerie;
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
            
            foreach(var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
