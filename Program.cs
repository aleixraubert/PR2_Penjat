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

            char option;

            int trys = 0;

            Console.WriteLine(MSG_Welcome);

            Console.WriteLine(MSG_Start);

            Console.WriteLine(MSG_Levels);

            option = Convert.ToChar(Console.ReadLine());


            switch (option)
            {
                case: 
            }
        }
    }
}