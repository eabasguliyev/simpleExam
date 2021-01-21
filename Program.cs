using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace simpleExamProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "simpleExam";

            GetData(out string[] questions, out string[][] answers);

            var points = 0;

            for (int i = 0; i < questions.GetLength(0); i++)
            {
                var randomAnswers = GetRandomAnswers(answers[i]);
                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine(questions[i]);
                PrintAnswers(randomAnswers);


                sbyte answerIndex;
                while (true)
                {
                    Console.Write("Your answer: ");

                    var answer = Console.ReadLine();

                    answerIndex = GetAnswerIndex(answer);
                    if (answerIndex >= 0)
                        break;
                    Console.WriteLine("Please, input correct answer!");
                }
                 

                Console.Clear();

                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine(questions[i]);
                if (randomAnswers[answerIndex] == randomAnswers[3])
                {
                    PrintCorrectAnswer(randomAnswers);
                    points += 10;
                }
                else
                {
                    PrintCorrectAndWrongAnswer(randomAnswers, (byte)answerIndex);

                    if (points != 0)
                        points -= 10;
                }

                if(i == questions.Length - 1)
                    Console.WriteLine("Press enter to continue");
                else
                    Console.WriteLine("Press enter for next question.");


                Console.ReadLine();
                Console.Clear();
            }

            PrintPoint(points);
        }

        public static void PrintPoint(int points)
        {
            Console.Write("Exam ended. Your points : ");

            if (points > 90)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (points > 80)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (points > 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (points > 60)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (points > 50)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(points);
            Console.ResetColor();

        }
        public static void GetData(out string[] questions, out string[][] answers)
        {
            const int questionsCount = 10;
            questions = new string[questionsCount];
            answers = new string[questionsCount][];

            questions[0] = "Azerbaycanin paytaxti haradir?";
            answers[0] = new string[4];
            answers[0][0] = "Baki";
            answers[0][1] = "Shamaxi";
            answers[0][2] = "Gence";
            answers[0][3] = answers[0][0]; // correct answer

            questions[1] = "Azerbaycan bayraghinda yashil reng neyi bildirir?";
            answers[1] = new string[4];
            answers[1][0] = "Yehudilik";
            answers[1][1] = "Islam";
            answers[1][2] = "Xristianliq";
            answers[1][3] = answers[1][1]; // correct answer


            questions[2] = "Ashagidakilardan hansi low level programlashdirma dilidir?";
            answers[2] = new string[4];
            answers[2][0] = "C#";
            answers[2][1] = "C";
            answers[2][2] = "Assembly";
            answers[2][3] = answers[2][2]; // correct answer

            questions[3] = "Schengen'e daxil olmayan olke?";
            answers[3] = new string[4];
            answers[3][0] = "Turkiye";
            answers[3][1] = "Bolqaristan";
            answers[3][2] = "Yunanistan";
            answers[3][3] = answers[3][0]; // correct answer

            questions[4] = "Amerika Birleshmish Shtatlarinin ilk prezidenti kimdir?";
            answers[4] = new string[4];
            answers[4][0] = "Avraam Linkoln";
            answers[4][1] = "Con Kennedi";
            answers[4][2] = "Corc Vashinqton";
            answers[4][3] = answers[4][2]; // correct answer

            questions[5] = "AXC'nin suqutu?";
            answers[5] = new string[4];
            answers[5][0] = "1919";
            answers[5][1] = "1920";
            answers[5][2] = "1921";
            answers[5][3] = answers[5][1]; // correct answer

            questions[6] = "Ashagidakilardan hansi blokchain texnologiyasi ile ishleyir?";
            answers[6] = new string[4];
            answers[6][0] = "Mastercard";
            answers[6][1] = "Paypal";
            answers[6][2] = "Bitcoin";
            answers[6][3] = answers[6][2]; // correct answer

            questions[7] = "Paypal'in yaradicilarindandir:";
            answers[7] = new string[4];
            answers[7][0] = "Elon Musk";
            answers[7][1] = "Bill Gates";
            answers[7][2] = "Jack Ma";
            answers[7][3] = answers[7][0]; // correct answer

            questions[8] = "Ashagidakilardan hansi emeliyyat sistemi deyil?";
            answers[8] = new string[4];
            answers[8][0] = "Mint";
            answers[8][1] = "ChromeOS";
            answers[8][2] = "Wine";
            answers[8][3] = answers[8][2]; // correct answer

            questions[9] = "Ethereum'un yaradicisi kimdir?";
            answers[9] = new string[4];
            answers[9][0] = "Sastoshi Nakamoto";
            answers[9][1] = "Vitalik Buterin";
            answers[9][2] = "Mark Zuckerberg";
            answers[9][3] = answers[9][1]; // correct answer
        }

        public static sbyte GetAnswerIndex(string answer)
        {
            if (!String.IsNullOrWhiteSpace(answer))
            {
                char variant = (char)(answer.ToUpper().ToCharArray()[0]);
                if (variant.Equals('A') || variant.Equals(('B')) || variant.Equals('C'))
                {
                    return (sbyte)(variant - 65);
                }
            }

            return -1;
        }
        public static void PrintAnswers(string[] answers)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
            }
        }

        public static void PrintCorrectAnswer(string[] answers)
        {
            for (int i = 0; i < 3; i++)
            {
                if (answers[i] != answers[3])
                {
                    Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
                Console.ResetColor();
            }
        }

        public static void PrintCorrectAndWrongAnswer(string[] answers, byte wrongAnswer)
        {
            for (int i = 0; i < 3; i++)
            {
                if (answers[i] == answers[3])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
                    Console.ResetColor();
                    continue;
                }
                else if (i == wrongAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine($"{(char)(65 + i)}) {answers[i]}");
            }
        }

        public static string[] GetRandomAnswers(string[] answers)
        {
            var random = new Random();

            var randomAnswers = new string[4];

            var numbers = String.Empty;

            var counter = 0;

            while (counter < 3)
            {
                var index = random.Next(0, 3);

                if (!numbers.Contains(index.ToString()))
                {
                    numbers += index.ToString();
                    randomAnswers[index] = answers[counter];
                    counter++;
                }
            }

            randomAnswers[3] = answers[3]; // correct answer
            return randomAnswers;
        }
    }
}
