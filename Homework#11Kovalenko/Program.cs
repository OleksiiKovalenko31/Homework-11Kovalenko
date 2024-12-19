using System.Text;
using System.Text.RegularExpressions;


namespace Homework_11Kovalenko
{
    internal class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
            Regex blend = new Regex("[0-9 !@#%&*()_=+a-zA-Z_]");
            while (true)
            {
                int index;
                bool win;
                char letter = ' ';
                Console.WriteLine("\tЗагадане слово:");
                string wort = QuestionWort(), msg;
                char[] tempWort = new char[wort.Length];
                Console.WriteLine("\t");
                // Виводемо пеший раз слово
                for (int i = 0; i < tempWort.Length; i++)
                {
                    tempWort[i] = '*';
                    Console.Write($"{tempWort[i]} ");
                }
                Console.WriteLine($"- Залишилось кількість спроб - {wort.Length}!");
                Console.WriteLine("----------------------------------------");

                for (int i = 0; i < wort.Length;) // Цикл на кількість спроб
                {
                    Console.WriteLine("\n");
                    Console.Write("Введіть літеру _ ");
                    bool letterOutBlend = char.TryParse(Console.ReadLine(), out letter);
                    int quantityLetter = wort.Count(ch => ch == letter);
                    bool symbol = (blend.IsMatch(Convert.ToString(letter)));

                    if (letterOutBlend && symbol == false) // Перевірка на помилку введення
                    {
                        if (quantityLetter > 1) // Якщо більше одной літери в слові
                        {
                            for (int j = 0; j < tempWort.Length; j++)
                            {
                                if (wort[j] == letter)
                                {
                                    tempWort[j] = letter;
                                }
                            }
                        }
                        else if (quantityLetter == 1 && symbol == false) // якщо одна літера
                        {
                            index = wort.IndexOf(letter);
                            tempWort[index] = letter;
                        }

                        Console.Clear();
                        foreach (var item in tempWort)
                        {
                            msg = $"{item} ";
                            Console.Write(msg.ToUpper());
                        }
                        i++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\tЗагадане слово:");
                        Console.WriteLine("Введіть тільки українськи літери!");
                        foreach (var item in tempWort)
                        {

                            msg = $"{item} ";
                            Console.Write(msg.ToUpper());
                        }
                    }
                    // Перевірка на виграш
                    if (Checkforwinnings(tempWort) && wort.Length - i != 0)
                    {
                        Console.WriteLine($"\tВітаю Ви вгадали слово < {wort} >");
                        break;
                    }
                    else if (!Checkforwinnings(tempWort) && wort.Length - i == 0)
                    {
                        Console.WriteLine($"\tНажаль Ви невгадали слово < {wort} >");
                    }
                    Console.WriteLine($"\tЗалишилось кількість спроб {wort.Length - i}!");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("\n");
                    Console.WriteLine($"Кількість літер {letter} - {quantityLetter}");
                    
   
                }
                // Запит на повтор
                Console.WriteLine();
                Console.Write("Спробувати знову: 1 - Так / 2 - Ні _ ");

                int.TryParse((Console.ReadLine()), out int exit);

                if (exit == 2)

                { break; }

                else if (exit == 1)

                {
                    Console.Clear();
                    continue; 
                }

                else { Console.WriteLine("Incorrect format"); }

            }

            static bool Checkforwinnings( char[] tempArray)
            {
                bool end;
                if (tempArray.Contains('*'))
                {
                    end = false;
                }
                else
                {
                    end = true;
                }
                return end;
            }

            static string QuestionWort()
            {
                string[] questionWort = ["містика", "залізо", "башта", "мексика"];
                Random rndQuestionWort = new Random();
                int indexWort = rndQuestionWort.Next(questionWort.Length);

                return questionWort[indexWort];
            }




        }
    }
}
