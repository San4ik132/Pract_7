using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
        struct dishesPersonss
        {

            public int quan;
            public string meas;
        }
        static Dictionary<string, List<dishesPersonss>> get_shop_list_by_dishes(List<string> dishes, int person_count)
        {

            var kapibara = new List<string> { };
            var dishesPersons = new Dictionary<string, List<dishesPersonss>> { };
            //foreach (var ttt in dishes)
            //{
            //    foreach (var ppp in FileData())
            //    {
            //        if (ttt != ppp.Key)
            //        {
            //            Console.WriteLine($"Такого  блюда {ttt} нет в файле");

            //        }
            //        break;
            //    }

            //}





            var cook_book = FileData();

            foreach (var ppp in cook_book)
            {
                foreach (var ttt in dishes)
                {

                    if (ttt == ppp.Key)
                    {

                        //var count = 0;
                        //var nams = string.Empty;
                        foreach (var ooo in ppp.Value)
                        {
                            var count = ppp.Value.Count;
                            var nams = ooo.name;
                            var ingredient = new List<dishesPersonss> { };
                            foreach (var i in dishesPersons)
                            {
                                if (i.Key == nams) nams = string.Empty;
                            }
                            for (int j = 0; j < count; j++)
                            {
                                ingredient.Add(new dishesPersonss
                                {
                                    quan = ooo.quantity * person_count,
                                    meas = ooo.measure,

                                });
                                break;
                            }


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
                {
                    Console.WriteLine($"{ppp.name} | {ppp.quantity} | {ppp.measure}");
                }
                Console.WriteLine();
            }

            //Console.WriteLine(get_shop_list_by_dishes(new List<string> { "Омлет" }, 2));
            var dishes = get_shop_list_by_dishes(new List<string> { "Омлет", "Фахитос", "Запеченный картофель" }, 2);
            foreach (var ttt in dishes)
            {
                Console.Write($"{ttt.Key} | ");
                foreach (var ppp in ttt.Value)
                {
                    Console.WriteLine($"{ppp.quan} | {ppp.meas}");
                }
                //Console.WriteLine();
            }

        }

    }

}


// 1. Чтение всего - хуйня
// 2. Закономерность. Не надо читать колличества блюд, а нужно читать остальные данные
// 3. При чтении сразу вносить в dicshonory
// 4. Ваня лох!