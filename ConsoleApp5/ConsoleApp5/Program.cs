using System;
using System.Collections.Generic;
using System.IO;

namespace practice_7
{
    internal class Program
    {
        struct Ingredient
        {
            public string name;
            public int quantity;
            public string measure;
        }

        static Dictionary<string, List<Ingredient>> FileData()
        {
            string path = "dishes.txt";
            var cook_book = new Dictionary<string, List<Ingredient>> { };
            //чтение и сапись в словарь
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    // считываю первую страку с названием блюда и заношу в переменную name
                    var name = reader.ReadLine();
                    // указываю на пустые строки
                    if (string.IsNullOrEmpty(name)) continue;
                    // считаю кол-во ингридиентов для определения их в структуре
                    var quantity = int.Parse(reader.ReadLine());
                    // созаю переменную в которой храню структуру 
                    var ingredients = new List<Ingredient> { };
                    // цикл для определения кол-во ингридиентов
                    for (int i = 0; i < quantity; i++)
                    {
                        // в переменную закидываю строки между символом '|' кроме самого символа т.ею обризаю их
                        var ingredient = reader.ReadLine().Split('|');
                        // добавляю в структуру данные из переменных
                        ingredients.Add(new Ingredient
                        {
                            name = ingredient[0].Trim(),
                            quantity = int.Parse(ingredient[1].Trim()),
                            measure = ingredient[2].Trim()
                        });

                    }
                    //добавляю всё в словарь
                    cook_book.Add(name, ingredients);
                }

                reader.Close();
            }

            return cook_book;
        }
        // Задание №2
        struct dishesPersons
        {

            public int quantity;
            public string measure;
        }
        static void get_shop_list_by_dishes(List<string> dishes, int person_count)
        {

        }

        static void Main()
        {
            // чисто для проверки данных в словаре
            foreach (var ttt in FileData())
            {
                Console.WriteLine(ttt.Key);
                Console.WriteLine(ttt.Value.Count);
                foreach (var ppp in ttt.Value)
                {
                    Console.WriteLine($"{ppp.name} | {ppp.quantity} | {ppp.measure}");
                }
                Console.WriteLine();
            }

        }

    }

}


// 1. Чтение всего - хуйня
// 2. Закономерность. Не надо читать колличества блюд, а нужно читать остальные данные
// 3. При чтении сразу вносить в dicshonory
// 4. Ваня лох!