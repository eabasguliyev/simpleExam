using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleExamProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData(out string[] questions, out string[][] answers);

            var points = 0;

            //for (int i = 0; i < questions.GetLength(0); i++)
            for (int i = 0; i < 2; i++)
            {
                var randomAnswers = RandomAnswers(answers[i]);
                Console.WriteLine($"Question {i + 1}");
                Console.WriteLine(questions[i]);
                PrintAnswers(randomAnswers);

                Console.Write("Your answer: ");

                string answer = String.Empty;

                while (true)
                {
                    answer = Console.ReadLine();

                    if (!String.IsNullOrWhiteSpace(answer))
                        break;
                    Console.WriteLine("Please enter the answer!");
                }

                var answerIndex = (byte)((answer.ToUpper().ToCharArray()[0]) - 65);

                Console.Clear();
                Console.WriteLine(questions[i]);
                if (randomAnswers[answerIndex] == randomAnswers[3])
                {
                    PrintCorrectAnswer(randomAnswers);
                    points += 10;
                }
                else
                {
                    PrintCorrectAndWrongAnswer(randomAnswers, answerIndex);

                    if (points != 0)
                        points -= 10;
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Exam ended. Your points : " + points);

        }

        public static void GetData(out string[] questions, out string[][] answers)
        {
            const int questionsCount = 10;
            questions = new string[questionsCount];
            answers = new string[questionsCount][];

            questions[0] = "Bakinin paytaxti haradir?";
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

        public static string[] RandomAnswers(string[] answers)
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
