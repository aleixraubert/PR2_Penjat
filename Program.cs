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
            const string MSG_Welcome = "┌─────────────────────────────────────────┐\n│ ░▄▄░░▄░░▄░▄▄▄▄░▄▄▄▄░▄▄▄▄░░▄▄░░▄▄▄░░▄▄▄▄ │\n│ █░░█░█░░█░█░░█░█░░█░█░░░░█░░█░█░░█░█░░█ │\n│ █▄▄█░█▀▀█░█░░█░█▀█░░█░░░░█▄▄█░█░░█░█░░█ │\n│ █░░█░█░░█░█▄▄█░█░░█░█▄▄▄░█░░█░█▄▄▀░█▄▄█ │\n└─────────────────────────────────────────┘";
            const string MSG_Start = "Bienvenid@ al ahorcado!\nPorfavor, escoge el nivel de dificultad:";
            const string MSG_Levels = "A. Fácil\nB. Normal\nC. Difícil\nD. Experto";
            const string MSG_Dfificulty = "Has escogido nivel de dificultad {0}!";
            const string MSG_Error_Option = "El crarácter introducido no es válido, vuelve a introducirlo.";

            string dificulty;

            char option;

            bool correct=false;

            int trys = 0;

            Console.WriteLine(MSG_Welcome);

            Console.WriteLine(MSG_Start);

            Console.WriteLine(MSG_Levels);

            option = Convert.ToChar(Console.ReadLine());

            while(!correct) 
            {
                switch (option)
                {
                    case 'a': 
                    case 'A': 
                        
                        trys = 7;
                        dificulty = "fácil";
                        Console.WriteLine(MSG_Dfificulty, dificulty);
                        correct=true;
                        break;
                    case 'b': 
                    case 'B': 

                        trys = 5;
                        dificulty = "normal";
                        Console.WriteLine(MSG_Dfificulty, dificulty);
                        correct=true;
                        break;
                    case 'c': 
                    case 'C': 

                        trys = 4;
                        dificulty = "difícil";
                        Console.WriteLine(MSG_Dfificulty, dificulty);
                        correct=true;
                        break;
                    case 'd': 
                    case 'D': 

                        trys = 3;
                        dificulty = "experto";
                        Console.WriteLine(MSG_Dfificulty, dificulty);
                        correct=true;
                        break;
                    default:

                        Console.WriteLine(MSG_Error_Option);
                        option = Convert.ToChar(Console.ReadLine());
                        break;
                }
            }
        }
    }
}