using System;
using System.Collections.Generic;
using System.IO;

namespace practice_7
{
    internal class Program
    {
        static string FileData()
        {
            string text = string.Empty;
            string path = "dishes.txt";
            //чтение
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
                reader.Close();
            }
            return text;
        }
        static List<string> ListStringsData()
        {
            //разбиение на подстроки
            List<string> Text = new List<string> { };
            string[] oper = FileData().Split('\n');
            for (int i = 0; i < oper.Length; i++) oper[i]?.Replace(" ", "");
            foreach (string ttt in oper) Text.Add(ttt.ToString());
            return Text;
        }
        static int IndividualDishes(List<string> ListDate)
        {
           
            int index = ListDate.IndexOf("\r");      
            return index;
        }

        static List<string> RemoveListStringsData(List<string> ListDate)
        {
            int index = ListDate.IndexOf("\r");
            ListDate.RemoveRange(0, index+1);
            return ListDate;
        }
        static void SaveDataList()
        {
            List<string> SaveDataList = new List<string> { };
            foreach (string ttt in ListStringsData())
            {
                SaveDataList.Add(ttt);
            }
            
            List<string> List1 = new List<string> { };
            List<string> List2 = new List<string> { };
            List<string> List3 = new List<string> { };
            List<string> List4 = new List<string> { };
            
            for (int i = 0; i < IndividualDishes(SaveDataList); i++){
                List1.Add(SaveDataList[i]);
            }
        
            RemoveListStringsData(SaveDataList);

            for (int i = 0; i < IndividualDishes(SaveDataList); i++)
            {
                List2.Add(SaveDataList[i]);
            }
         
            RemoveListStringsData(SaveDataList);

            for (int i = 0; i < IndividualDishes(SaveDataList); i++)
            {
                List3.Add(SaveDataList[i]);
            }

            RemoveListStringsData(SaveDataList);


            for (int i = 0; i < SaveDataList.Count; i++)
            {
                List4.Add(SaveDataList[i]);
            }

            RemoveListStringsData(SaveDataList);

            foreach (string ttt in List1)
            {
                Console.WriteLine(ttt);
            }
                Dictionary<string, string> cook_book = new Dictionary<string,string > { };



        }
        static void Main()
        {



            SaveDataList();



        }


    }
}


// 1. Чтение всего - хуйня
// 2. Закономерность. Не надо читать колличества блюд, а нужно читать остальные данные
// 3. При чтении сразу вносить в dicshonory
// 4. Ваня лох!