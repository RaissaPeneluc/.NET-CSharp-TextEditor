using System.IO;

Menu();

static void Menu()
{

    Console.Clear();
    Console.WriteLine("Escolha a opção desejada:");
    Console.WriteLine("--------------------------");
    Console.WriteLine(" ");
    Console.WriteLine("1 -  Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair ");
    Console.WriteLine(" ");
    Console.WriteLine("--------------------------");
    short op = short.Parse(Console.ReadLine());

    switch (op)
    {
        case 0:
            System.Environment.Exit(0);
            break;

        case 1:
            Abrir();
            break;

        case 2:
            Editar();
            break;

    }
}

static void Abrir()
{

    Console.Clear();
    Console.WriteLine("Digite o caminho do arquivo:");
    string path = Console.ReadLine();

    // É usado sempre para ler ou salvar algum arquivo
    using (var file = new StreamReader(path))
    {

        // ReadToEnd => Ler o arquivo até o final
        string text = file.ReadToEnd();
        Console.WriteLine(text);

    }

    Console.WriteLine("");
    Console.ReadLine();

    Menu();


}

static void Editar()
{

    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo: (ESC para sair)");
    Console.WriteLine("-------------------------");
    string text = "";

    // Estrutura de repetição para ler uma tecla, no caso ESC, e sair da repetição caso essa tecla for selecionada.
    do
    {

        // Tudo que já está em text, mais o que o usuário digita.
        text += Console.ReadLine();

        // Quebrando a linha no fim de cada leitura
        text += Environment.NewLine;

    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(text);
}

static void Salvar(string text)
{

    Console.Clear();
    Console.WriteLine("Qual o caminho para salvar o arquivo?");
    var path = Console.ReadLine();


    // Using => Abre e fecha automaticamente o objeto

    // StreamWritter => Fluxo de escrita, de bytes, obrigatório fechar

    using (var file = new StreamWriter(path))
    {

        // Escreve o arquivo
        file.Write(text);

    }

    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    Console.ReadLine();

    Menu();
}