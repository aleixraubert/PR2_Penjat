/* Joc PR2 Penjat
 * Autor: Aleix Raubert
*/

using System;


namespace PR2
{
    public class Penjat
    {
        static void Main()
        {
            const string MSG_WELCOME = "┌─────────────────────────────────────────┐\n│ ░▄▄░░▄░░▄░▄▄▄▄░▄▄▄▄░▄▄▄▄░░▄▄░░▄▄▄░░▄▄▄▄ │\n│ █░░█░█░░█░█░░█░█░░█░█░░░░█░░█░█░░█░█░░█ │\n│ █▄▄█░█▀▀█░█░░█░█▀█░░█░░░░█▄▄█░█░░█░█░░█ │\n│ █░░█░█░░█░█▄▄█░█░░█░█▄▄▄░█░░█░█▄▄▀░█▄▄█ │\n└─────────────────────────────────────────┘";
            const string MSG_START = "Bienvenid@ al ahorcado!\nPorfavor, escoge el nivel de dificultad:";
            const string MSG_LEVELS = "A. Fácil\nB. Normal\nC. Difícil\nD. Experto";
            const string MSG_DIFICULTY = "Has escogido nivel de dificultad {0}!\n";
            const string MSG_ERROR_OPTION = "El crarácter introducido no es válido, vuelve a introducirlo.";
            const string MSG_USER_TEXT = "Ahora introduce un texto de N palabras, separadas por espacios y sin puntos ni comas. Puedes usar las siguientes letras:\n";
            const string MSG_GAME_START = "Comienza el juego, buena suerte!\n";
            const string MSG_TRYS = "Número de intentos restantes: {0}\n";
            const string MSG_ENTER_LETTER = "Teclee una letra (vocal o consonante)\n";
            const string MSG_LETTER_CORRECT = "La letra {0} está en la palabra!\n";
            const string MSG_LETTER_INCORRECT = "La letra {0} no está en la palabra...\n";
            const string MSG_WIN = "Enhorabuena has adivinado la palabra!!!\n";
            const string MSG_LOSS = "Mala suerte... No has adivinado la palabra. Esta era: {0}.\n";
            const string MSG_REPITED = "La letra {0} ya ha sido adivinada anteriormente.\n";
            const string LINE_JUMP = "\n\n";

            char[] alph = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            string dificulty = "", final_word = "";

            char option, letter;

            bool correct = false, started = true, is_in_word = false, word_complete = false, letter_repited = false;

            int trys = 0, n;

            Console.WriteLine(MSG_WELCOME);

            Console.WriteLine(MSG_START);

            Console.WriteLine(MSG_LEVELS);

            option = Convert.ToChar(Console.ReadLine());

            while (!correct)
            {
                switch (option)
                {
                    case 'a':
                    case 'A':

                        trys = 7;
                        dificulty = "fácil";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;
                    case 'b':
                    case 'B':

                        trys = 5;
                        dificulty = "normal";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;
                    case 'c':
                    case 'C':

                        trys = 4;
                        dificulty = "difícil";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;
                    case 'd':
                    case 'D':

                        trys = 3;
                        dificulty = "experto";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;
                    default:

                        Console.WriteLine(MSG_ERROR_OPTION);
                        option = Convert.ToChar(Console.ReadLine());
                        break;
                }
            }

            Console.WriteLine(MSG_USER_TEXT);


            foreach (char letra in alph)
            {
                Console.Write($"{letra} ");
            }

            Console.Write(LINE_JUMP);

            string user_input = Console.ReadLine();

            user_input = user_input.ToUpper();

            string[] posibles_words = user_input.Split(' ');


            for (int i = 0; i < posibles_words.Length - 1; i++)
            {
                for (int j = 0; j < posibles_words.Length - 1; j++)
                {
                    if (posibles_words[j].Length > posibles_words[j + 1].Length)
                    {
                        string temp = posibles_words[j];
                        posibles_words[j] = posibles_words[j + 1];
                        posibles_words[j + 1] = temp;
                    }
                }
            }


            switch (dificulty)
            {
                case "fácil":
                    final_word = posibles_words[0];

                    break;
                case "normal":
                    n = (posibles_words.Length / 2) - 1;
                    if (n < 0) n = 0;
                    final_word = posibles_words[n];

                    break;
                case "difícil":
                    n = (posibles_words.Length / 2);
                    if (n > posibles_words.Length) n = posibles_words.Length;
                    final_word = posibles_words[n];

                    break;
                case "experto":
                    final_word = posibles_words[posibles_words.Length - 1];

                    break;
            }

            char[] guess = new char[final_word.Length];


            for (int i = 0; i < final_word.Length; i++)
            {
                guess[i] = '_';
            }

            Console.WriteLine(MSG_GAME_START);

            while (started && trys > 0)
            {
                Console.WriteLine(MSG_TRYS, trys);

                for (int i = 1; i <= alph.Length; i++)
                {
                    Console.Write($"{alph[i - 1]} ");

                    if (i % 9 == 0) Console.WriteLine();
                }

                Console.WriteLine();

                foreach (char c in guess) Console.Write($"{c} ");

                Console.Write(LINE_JUMP);


                switch (trys)
                {
                    case 7:
                        Console.Write("+=======+\n|\n|\n|\n|\n|\n============");
                        break;

                    case 6:
                        Console.Write("+=======+\n|       |\n|\n|\n|\n|\n============");
                        break;

                    case 5:
                        Console.Write("+=======+\n|       |\n|       O\n|\n|\n|\n============");
                        break;

                    case 4:
                        Console.Write("+=======+\n|       |\n|       O\n|      / \n|\n|\n============");
                        break;

                    case 3:
                        Console.Write("+=======+\n|       |\n|       O\n|      /| \n|\n|\n============");
                        break;

                    case 2:
                        Console.Write("+=======+\n|       |\n|       O\n|      /|\\ \n|\n|\n============");
                        break;

                    case 1:
                        Console.Write("+=======+\n|       |\n|       O\n|      /|\\ \n|      /  \n|\n============");
                        break;

                    case 0:
                        break;
                }

                Console.Write(LINE_JUMP);

                Console.WriteLine(MSG_ENTER_LETTER);

                letter = Convert.ToChar(Console.ReadLine());

                letter = Char.ToUpper(letter);

                letter_repited = false;

                foreach(char c in guess)
                {
                    if(c==letter) letter_repited = true;
                }

                

                if (!letter_repited) 
                {

                    for (int i = 0; i < final_word.Length; i++)
                    {
                        if (letter == final_word[i])
                        {
                            guess[i] = letter;
                            is_in_word = true;
                        }
                    }

                    if (!is_in_word)
                    {
                        trys--;
                        Console.WriteLine(MSG_LETTER_INCORRECT, letter);
                    }
                    else
                    {
                        Console.WriteLine(MSG_LETTER_CORRECT, letter);
                    }


                    word_complete = true;

                    foreach (char c in guess)
                    {
                        if (c == '_') word_complete = false;
                    }


                    if (word_complete) started = false;

                    for(int i=0; i<alph.Length; i++)
                    {
                        if (letter == alph[i])
                        {
                            alph[i] = '-';
                        }
                    }
                }
                else
                {
                    Console.WriteLine(MSG_REPITED, letter);
                }
            }

            if (trys > 0)
            {
                Console.WriteLine(MSG_WIN);
                foreach (char c in guess) Console.Write($"{c} ");
                Console.WriteLine();
            }
            else
            {
                Console.Write("+=======+\n|       |\n|       X\n|      /|\\ \n|      / \\ \n|\n============\n");

                Console.WriteLine(MSG_LOSS, final_word);
            }
        }
    }
}