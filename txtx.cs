using System;
using System.Linq;
using System.Net;

class SimpleClient
{
    public static string Criptografar(string entrada)
    {
        string saida = "";

        foreach (char c in entrada)
        {
            // Adiciona 32 ao valor ASCII do caractere e converte de volta para char
            char novoCaractere = (char)(c - 32);

            // Adiciona o novo caractere à string de saída
            saida += novoCaractere;
        }

        return saida;
    }
    static void Main(string[] args)
    {
        string url = "https://www.microsoft.com/"; // endereço a ser requisitado
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        if (args.Count() > 0) url = args[0].ToString(); 
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET"; // define o método da requisição

        HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // faz a requisição e recebe a resposta

        // lê o conteúdo da resposta
        using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
        {
            string responseText = streamReader.ReadToEnd();
            Console.WriteLine(Criptografar(responseText));
        }

        response.Close(); // fecha a conexão com o servidor
    }
}
