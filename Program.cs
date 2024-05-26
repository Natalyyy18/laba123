using ClassLibrary10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_12_би_дерево
{
    internal class Program
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t<<<<<Меню>>>>>\n");
            Console.WriteLine("1. Сформировать дерево\n" +
                "2. Печать деревьев \n" +
                "3. Среднее арифметическое балансов\n" +
                "4. Преобразование в дерево поиска\n" +
                "5. Удаление элементов\n" +
                "6. Добавление элементов\n" +
                "7. Удаление из памяти\n" +
                "");
        }
       


        static void Main(string[] args)
        {
            string answer = null;
            MyTree<DebitCard> tree = null;
            MyTree<DebitCard> treeBST = null;



            PrintMenu();

            while (answer != "8")
            {
                Console.Write("Ваш выбор: ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        tree = new MyTree<DebitCard>(6);
                        Console.WriteLine("Дерево сформировано");
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("\n\t\t|||Сбалансированное дерево|||\n");
                            tree.ShowTree();
                            if (treeBST != null)
                            {
                                Console.WriteLine("\n\t\t|||Бинарное дерево поиска|||\n");
                                treeBST.ShowTree();
                            }

                        }

                        catch
                        {
                            Console.WriteLine("Сначала сформируйте исд дерево.");
                        }
                       
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("\n\t\t|||Среднее арифметическое балансов:|||\n");
                            Console.WriteLine(tree.GetAverageBalance() );
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте исд дерево.");
                        }
                        break;
                    case "4":
                        if (tree != null)
                        {
                            treeBST = new MyTree<DebitCard>(6);
                            tree.MadeFromTreeToFindTree(treeBST);
                            Console.WriteLine("Дерево преобразовано");
                        }
                        else
                            Console.WriteLine("В дереве не было элементов");
                        break;
                    case "5":
                        if (tree != null)
                        {
                            int tc = tree.Count;
                            DebitCard deb = new DebitCard();
                            deb.Init();
                            tree.Remove(deb);
                            if (tc > tree.Count)
                                Console.WriteLine("Элемент удален");
                            else
                                Console.WriteLine("Элемент не найден");
                        }
                        else
                            Console.WriteLine("Сначала сформируйте дерево");
                        break;
                    case "6":
                        if (tree != null)
                        {
                            DebitCard deb1 = new DebitCard();
                            deb1.Init();
                            tree.AddPoint(deb1);
                            Console.WriteLine("Элемент добавлен");
                        }
                        else
                            Console.WriteLine("Сначала сформируйте дерево");
                        break;
                    case "7":
                        if (tree != null)
                        {
                            tree.Clear();
                            Console.WriteLine("Дерево удалено");
                        }
                        else
                            Console.WriteLine("В дереве не было элементов");
                        break;


                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;



                }
            }
        }
    }
}
