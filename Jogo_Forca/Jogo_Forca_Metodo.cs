using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Forca
{
    internal class Jogo_Forca_Metodo
    {

        // Método para receber a palavra do usuário
        public static string Digitar_palavra()
        {

        // GOTO, caso o usuário erre a palavra
        palavra_errada:

            //Pedindo para o usuário digitar a palavra
            Console.WriteLine("Digite a palavra que será adivinhada palavra! (SEM ACENTO)");

            // Criando uma string para receber a palavra e atribuindo um valor a ela
            string palavra;
            palavra = Console.ReadLine();

            // Conferindo se o jogador não escreveu a palavra errado.
            Console.WriteLine("Digitou a palavra corretamente? (S) ou (N)");
            char sim_nao;
            sim_nao = char.Parse(Console.ReadLine());

            // Switch-Case, caso o jogador tenha escrito certo o método retorna a palavra digitada.
            // Caso o jogador tenha digitado a palavra errada, ele retorna ao início do método para reescrevela.
            switch (sim_nao)
            {
                case 's':
                case 'S':
                    Console.Clear();
                    break;

                case 'n':
                case 'N':
                    Console.Clear();
                    goto palavra_errada;

                default:
                    break;
            }

            // Retornando a string.
            return palavra;

        }

    }
}
