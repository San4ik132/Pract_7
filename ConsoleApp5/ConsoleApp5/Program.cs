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
            public int quan;
            public string meas;
        }

        static Dictionary<string, List<dishesPersons>> get_shop_list_by_dishes(List<string> dishes, int person_count)
        {

            var kapibara = new List<string> { };
            var cook_book = FileData();
            var dishesPersons = new Dictionary<string, List<dishesPersons>> { };
            var k = 0;

            foreach (var kyeDishes in cook_book)
            {
                foreach (var stringDishes in dishes)
                {
                    if (stringDishes == kyeDishes.Key)
                    {
                        foreach (var items in kyeDishes.Value)
                        {
                            var nams = items.name;
                            var r = string.Empty;
                            var m = string.Empty;
                            var ingredient = new List<dishesPersons> { };
                            foreach (var i in dishesPersons)
                            {
                                if (i.Key == nams)
                                {
                                    foreach (var j in i.Value)
                                    {
                                        k = j.quan;
                                        r = nams;
                                    }

                                }

                            }
                        
                            dishesPersons.Remove(r);
                            ingredient.Add(new dishesPersons
                            {
                                quan = items.quantity * person_count + k,
                                meas = items.measure,
                            });
                            k = 0;
                            dishesPersons.Add(nams, ingredient);
                        }
                    }
                }
            }
            return dishesPersons;
        }

        static void Main()
        {
            // чисто для проверки данных в словаре
            var cook_book = FileData();
            foreach (var ttt in cook_book)
            {
                Console.WriteLine(ttt.Key);
                Console.WriteLine(ttt.Value.Count);

                foreach (var ppp in ttt.Value)
                    Console.WriteLine($"{ppp.name} | {ppp.quantity} | {ppp.measure}");

                Console.WriteLine();
            }
            // Вывод функции
            var dishes = get_shop_list_by_dishes(new List<string> { "Омлет", "Фахитос", "Утка по-пекински" }, 2);
            foreach (var ttt in dishes)
            {
                Console.Write($"{ttt.Key} | ");

                foreach (var ppp in ttt.Value)
                    Console.WriteLine($"{ppp.quan} | {ppp.meas}");
            }

        }
            
    }
}