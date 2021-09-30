using System;
using System.Text;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = { "promenad", "svar", "hund", "koda", "sushi", "film", "dela", "kund", "guld", "materia" };
            string secretWord, test, test2, test3;
            char playerGuess;
            Boolean result = true;
            StringBuilder usedLetter = new StringBuilder();
            Random randomNumber = new Random();



            while (true)
            {
                Console.WriteLine("Hangman Game");
                Console.WriteLine("____________\n");
                Console.WriteLine("Guess a Swedish Word");
                Console.WriteLine("You have ten guesses to use before losing");

                secretWord = words[randomNumber.Next(0, 10)];//Pick a random word to guess on
                char[] correctWord = new char[secretWord.Length];//setting upp the secret word in a array counting lenght and hiddes letters from user.
                for (int i = 0; i < correctWord.Length; i++)
                    correctWord[i] = '-';
                int guessQuantity = 0;
                usedLetter.Clear();


                while (true)
                {
                    if (guessQuantity > 9)
                    {
                        Console.WriteLine("You Lost ");
                        break;
                    }

                    Console.WriteLine("Write a letter and push enter to guess");
                    Console.WriteLine("or type 0 and enter to guess on a word");
                    Console.WriteLine("\nHow many times you have guessed: " + guessQuantity);
                    Console.WriteLine(("\nLetters you already guessed on:\n") + usedLetter + ("\n"));
                    Console.WriteLine("Word you gussing on");
                    Console.WriteLine(correctWord);
                   
                    playerGuess = GetLetter();

                    test3 = usedLetter.ToString();//preapering test to look if the word was gussed on before

                    if (playerGuess != '0')
                    {
                        usedLetter.Append(playerGuess); //adds letter to gussed word list
                        for (int i = 0; i < secretWord.Length; i++) //test if user input match hiden word and replace - if so
                        {
                            if (playerGuess == secretWord[i])
                                correctWord[i] = playerGuess;
                        }
                        test = new string(correctWord); //convert array to string and test resultat
                        if (String.Equals(secretWord, test))
                        {
                            win(secretWord);
                            break;
                        }
                    }
                    else if (playerGuess == '0')
                    {
                        Console.WriteLine("type a word");
                        test2 = Console.ReadLine();
                        if (String.Equals(secretWord, test2))
                        {
                            win(secretWord);
                            break;
                        }
                        else
                            guessQuantity = guessQuantity + 1;
                    }


                    if (result != test3.Contains(playerGuess) && playerGuess != '0') //test to look if the word was gussed on before
                    {
                        guessQuantity = guessQuantity + 1;

                    }

                }
                Console.WriteLine("Play again? type any key for yes or n to quit and press enter");
                playerGuess = GetLetter();
                if (playerGuess == 'n')
                {
                    break;
                }

            }

        }
        //Test user input
        static char GetLetter()
        {
            char num1 = 'a';
            bool inputTest = false;
            while (!inputTest)
            {
                inputTest = char.TryParse(Console.ReadLine(), out num1);
                if (!inputTest)
                    Console.WriteLine("Not valid input, type one letter ");
            }
            return num1;
        }
        static void win(string secretWord)
        {
            Console.WriteLine("You won, secret word was " + secretWord);
            
        }
         
      
    }
}

/*Random r1 = new Random();
            for (int i =0; i< 10; i++)
            {
                Console.WriteLine(r1.Next(5,11));
            }*/
/*if (secretWord.Contains(letter))
                    Console.WriteLine("yes");*/
/*private static void RandomGenerator (Random randomNumber)
        {
            Console.WriteLine(randomNumber.Next(0,11));
        }*/