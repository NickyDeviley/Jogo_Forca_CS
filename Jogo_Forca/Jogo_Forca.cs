using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_Forca
{
    internal class Jogo_Forca
    {

        public static void Main()
        {

            // Jogo da forca!
            /*
                Lógica:
                Jogador digita uma frase que é armazenada em uma string.
                Após digitar a tela é limpa.
                A frase deve ser quebrada em caractéres e armazenada em um vetor de char.
                Caso tenha espaços, eles devem ser preenchidos com "-"
                Então o jogador deve tentar acertar, a cada erro um contador na tela aumenta.
                Quando um contador chegar ao limite o jogador perde e a palavra é revelada.
            */

            // Método para receber a palavra do usuário
            string palavra = Jogo_Forca_Metodo.Digitar_palavra();

            // Criando um vetor vazio com o mesmo tamanho da palavra que será adivinhada.
            char[] palavra_Q = new char[palavra.Length];

            // Criando um vetor para facilitar
            char[] palavra_Z = new char[palavra.Length];

            // Criando um vetor para armazenar as letras já digitadas
            char[] palavra_x = new char[26];

            // Declarando todos os espaços do vetor como espaços.
            for (int i = 0; i < 26; i++)
            {
                palavra_x[i] = ' ';
            }

            int j = 0;

            foreach (char n in palavra)
            {
                // Identifica aonde está o espaço para trocar por uma "-"
                if (n == ' ')
                {
                    palavra_Z[j] = '-';
                    palavra_Q[j] = '-';
                    j++;
                }
                // Caso não seja espaço, ele adiciona uma "_"
                else
                {
                    palavra_Z[j] = n;
                    palavra_Q[j] = '_';
                    j++;
                }
                // Teste
                // Console.WriteLine(n);
            }



            // Sistema do jogo:
            byte tentativas = 0;
            char tentar = ' ';
            int tamanho = Convert.ToInt32(palavra_Z.GetLongLength(0));
            int verif_tamanho = 0;
            int contador = 0;
            bool jogo = true;
            bool val = false;
            j = 0;
            int x = 0;


            while (jogo)
            {

                Console.WriteLine("Tentativas: {0}", tentativas);
                foreach (char n in palavra_x)
                {
                    if (n != ' ')
                    {
                        Console.Write(" {0},", n);
                    }
                }
                Console.WriteLine("\n");
                foreach (char n in palavra_Q)
                {
                    Console.Write(n);
                }
                Console.WriteLine("\n\n");
                Console.WriteLine("Digite o caractére desejado:");

                // Recebendo caractére do usuário
                tentar = char.Parse(Console.ReadLine());

                palavra_x[x] = tentar;
                x++;

                contador = 0;

                // Verificando se o caractére existe dentro do array
                for (int i = 0; i < tamanho; i++)
                {
                    // Se a posição do array for um espaço ele pula
                    if (palavra_Q[i] == '-')
                    {
                        continue;
                    }
                    // Se o caractére do usuário for igual ao caractére na posição X
                    // O caractére é atribuído naquela posição
                    else if (tentar == palavra_Z[i])
                    {
                        palavra_Q[i] = tentar;
                        val = false;
                        contador++;
                    }
                    // Caso nenhuma das suas sejam verdade
                    else if (contador <= 0)
                    {
                        val = true;
                    }
                }

                if (val)
                {
                    tentativas++;
                }
                if (tentativas >= 6)
                {
                    jogo = false;
                    break;
                }

                // Laço para detectar se todas as letras de ambos os vetores são exatamente iguais
                foreach (char n in palavra_Z)
                {
                    // Verifica se o valor no espaço atual é igual ao valor do array com a palavra
                    if (palavra_Q[j] == n)
                    {
                        // Console.WriteLine(j);
                        // Se for verdadeiro, aumenta em 1 a quantidade de acertos
                        verif_tamanho++;
                        j++;
                    }
                    // Caso algum valor seja diferente entra aqui
                    else
                    {
                        // Ele reseta o valor e sai do loop para o jogador tentar de novo
                        verif_tamanho = 0;
                        j = 0;
                        break;
                    }
                }

                // Verifica se todos os caractéres são iguais
                if (verif_tamanho == tamanho)
                {
                    // Caso sejam todos iguais, a variável que mantém o laço vira falsa
                    // e o break saí do laço
                    jogo = false;
                    break;
                }

                Console.Clear();

            }

            // Caso tenha saído do laço, o jogador venceu!
            if (jogo == false && verif_tamanho == tamanho)
            {
                Console.Clear();
                // Mensagem de vitória!
                Console.WriteLine("Parabéns, você ganhou!");
                Console.WriteLine("A palavra era: {0}", palavra);
            }
            // Caso tenha saído do laço, mas todas as letras não sejam iguais.
            else if (jogo == false && verif_tamanho != tamanho)
            {
                Console.Clear();
                // Mensagem de derrota!
                Console.WriteLine("Infelizmente você perdeu!");
                Console.WriteLine("A palavra era: {0}", palavra);
            }

        }

    }
}
