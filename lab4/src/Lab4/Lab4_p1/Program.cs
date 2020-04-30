using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] actors = { "Операция Пластилин", "Noize NC", "Пицца", "Hospital", "Суп Харчо", "4 позиции Бруно" , "П", "П"};

            // строки, содержащие подстроку
            var request1 = from a in actors // определяем каждый объект из actors как a
                           where a.Contains("ун") //фильтрация по критерию
                           orderby a  // упорядочиваем по возрастанию
                           select a; // выбираем объект
            print(request1.ToArray());

            // отсортированные строки
            var request2 = from a in actors // определяем каждый объект из actors как a
                           orderby a  // упорядочиваем по возрастанию
                           select a; // выбираем объект
            print(request2.ToArray());

            // (точечный синтаксис) количество строк, являющихся уникальными
            var stringCounter = actors.Distinct().OrderBy(t => t).Count();
            print(new string[] { stringCounter.ToString() });

            // группировка строк по первой букве. В результат — буква, количество строк (генерация объектов «на лету»).
            var request4 = from actor in actors
                           group actor by actor[0] into g
                           select new { Name = g.Key, Count = g.Count() };
            foreach (var customPair in request4)
                Console.WriteLine($"{customPair.Name} : {customPair.Count}");

            Console.WriteLine();

            var request4_1 = actors.GroupBy(p => p[0]).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var customPair in request4_1)
                Console.WriteLine($"{customPair.Name} : {customPair.Count}");


            Console.ReadKey();
        }

        private static void print(string[] array)
        {
            foreach (string item in array)
                Console.WriteLine(item);

            Console.WriteLine();
        }
    }
}
