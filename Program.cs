using Senai_UC15_SA2.classes;

string? opcao;

do
{
    Console.Clear();
    Console.WriteLine(@"

        1 - Cadastrar PJ
        2 - Listar PJ
        0 - Sair

    ");

    opcao = Console.ReadLine();

    pessoaJuridica metodosPj = new pessoaJuridica();

     switch (opcao)
     {
        case "0":
            break;
        
        case "1":

            pessoaJuridica pj = new pessoaJuridica();

            Console.WriteLine("Digite o nome da PJ: ");
            pj.Nome = Console.ReadLine();

            Console.WriteLine("Informe o rendimento: ");
            pj.Rendimento = float.Parse(Console.ReadLine()!);

            bool valido;

            do
            {
                Console.WriteLine("Informe um CNPJ válido (ex: xx.xxx.xxx/0001-xx): ");
                pj.CNPJ = Console.ReadLine();
                valido = pj.ValidarCnpj(pj.CNPJ!);

            } while (valido == false);

            metodosPj.Inserir(pj);

            Console.WriteLine($"Cadastro realizado com Sucesso!");
            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadLine();

            break;
        
        case "2":

            Console.WriteLine($"Digite o nome do arquivo que deseja ler: ");
            string nomeArquivo = Console.ReadLine()!;

            pessoaJuridica pessoaJuridica = metodosPj.Ler(nomeArquivo);

            Console.WriteLine(@$"

                Nome: {pessoaJuridica.Nome}
                Rendimento: {pessoaJuridica.Rendimento}
                CNPJ: {pessoaJuridica.CNPJ}

            ");

            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadLine();

            break;
        
        default:
            Console.WriteLine("Opção Invalida!");
            Console.WriteLine("Aperte Enter para continuar");
            Console.ReadLine();
            break;
     }

} while (opcao != "0");
