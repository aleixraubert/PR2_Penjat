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
            //Declaració de constants i missatges per al usuari.
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

            //Declaració de variables i del abecedari.
            char[] alph = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            string dificulty = "", final_word = "";

            char option, letter;

            bool correct = false, started = true, is_in_word = false, word_complete = false, letter_repited = false;

            int trys = 0, n;

            //Missatges de benvinguda.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MSG_WELCOME);

            Console.WriteLine(MSG_START);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MSG_LEVELS);

            option = Convert.ToChar(Console.ReadLine());

            //Switch per a la selecció de la dificultad, on s'asigna els intents.
            while (!correct)
            {
                switch (option)
                {
                    case 'a':
                    case 'A':
                        Console.ForegroundColor = ConsoleColor.Green;
                        trys = 7;
                        dificulty = "fácil";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;

                    case 'b':
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        trys = 5;
                        dificulty = "normal";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;

                    case 'c':
                    case 'C':
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        trys = 4;
                        dificulty = "difícil";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;

                    case 'd':
                    case 'D':
                        Console.ForegroundColor = ConsoleColor.Red;
                        trys = 3;
                        dificulty = "experto";
                        Console.WriteLine(MSG_DIFICULTY, dificulty);
                        correct = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(MSG_ERROR_OPTION);
                        option = Convert.ToChar(Console.ReadLine());
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(MSG_USER_TEXT);

            // Bucle per imprimir el abecedari en pantalla.
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char letra in alph)
            {
                Console.Write($"{letra} ");
            }

            Console.Write(LINE_JUMP);

            //Entrada del text de l'usuari, on se separa per paraules i es guarda en un array de strings.
            string user_input = Console.ReadLine();

            user_input = user_input.ToUpper();

            string[] posibles_words = user_input.Split(' ');

            //Ordenació per BubbleSort del array.
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

            //Selecció de la paraula a endevinar en funció de la dificultat. (Com més baixa sigui la dificultat més curta serà la paraula i viciversa amb difícil).
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

            //Creació de la paraula a endevinar amb els _ espais corresponents.
            for (int i = 0; i < final_word.Length; i++)
            {
                guess[i] = '_';
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MSG_GAME_START);

            //Bucle de joc.
            while (started && trys > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(MSG_TRYS, trys);

                //Escriure per pantalla el abecedari en forma de taula. Com sabem que té 27 lletres i ho volem amb tres linees, les separem per multiples de 9, osigui 9 lletres a cada linea.
                Console.ForegroundColor = ConsoleColor.Magenta;
                for (int i = 1; i <= alph.Length; i++)
                {
                    Console.Write($"{alph[i - 1]} ");

                    if (i % 9 == 0) Console.WriteLine();
                }

                Console.WriteLine();

                //Escriure per pantalla la paraula a endevinar.
                Console.ForegroundColor = ConsoleColor.Gray;
                foreach (char c in guess) Console.Write($"{c} ");

                Console.Write(LINE_JUMP);

                //Dibuix del penjat en funció dels intents restants.
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(MSG_ENTER_LETTER);

                //Demana al usuari una lletra.
                letter = Convert.ToChar(Console.ReadLine());

                letter = Char.ToUpper(letter);

                letter_repited = false;

                //Comproba si la lletra ja ha estat endevinada anteriorment.
                foreach(char c in guess)
                {
                    if(c==letter) letter_repited = true;
                }

                
                //En cas de no have estat adivinada procedeix a comprobar si hi és a la paraula o no.
                if (!letter_repited) 
                {

                    //Comprobació de la lletra és a la paraula.
                    for (int i = 0; i < final_word.Length; i++)
                    {
                        if (letter == final_word[i])
                        {
                            guess[i] = letter;
                            is_in_word = true;
                        }
                    }

                    //Missatge en funció de si hi es o no.
                    if (!is_in_word)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        trys--;
                        Console.WriteLine(MSG_LETTER_INCORRECT, letter);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(MSG_LETTER_CORRECT, letter);
                    }

                    is_in_word = false;

                    word_complete = true;

                    //Comprobació de si s'ha endevinat tota la paraula o no.
                    foreach (char c in guess)
                    {
                        if (c == '_') word_complete = false;
                    }

                    
                    if (word_complete) started = false;

                    //Modificació al abecedari per eliminar la lletra introduida.
                    for(int i=0; i<alph.Length; i++)
                    {
                        if (letter == alph[i])
                        {
                            alph[i] = '-';
                        }
                    }
                }
                else //Misatge per notificar al jugador que la lletra ja ha estat endevinada anteriorment.
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(MSG_REPITED, letter);
                }
            }


            //Comprobació de si el usuari ha guanyat o ha perdut.
            if (trys > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(MSG_WIN);
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (char c in guess) Console.Write($"{c} ");
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("+=======+\n|       |\n|       X\n|      /|\\ \n|      / \\ \n|\n============\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MSG_LOSS, final_word);
            }
        }
    }
}