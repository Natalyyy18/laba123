using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary10;

namespace Лаба_12_би_дерево
{
    public class MyTree<T> where T :IInit, IComparable, new()
    {
        public bool IsFindTree;
        Point<T> root = null;
        int count = 0;
        public int Count => count;
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
            
        }

        public void ShowTree()
        {
            Show(root);
        }

        Point<T> MakeTree(int length, Point<T> point)
        {
            T data = new T();
            data.RandomInit();
            var milliseconds = 300;
            Thread.Sleep(milliseconds);
            Point<T> newItem = new Point<T>(data);
            if(length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl - 1; // Определяем количество элементов в правой ветке
            newItem.Left=MakeTree(nl,newItem.Left);
            newItem.Right=MakeTree(nr,newItem.Right); 
            return newItem;
        }

        void Show(Point<T> point, int spaces = 5)
        {
            if(point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public void AddPoint(T data)
        {
            if (count == 0)
            {
                root = new Point<T>(data); //создается корневая точка с этим значением
                count++;
            }
            else
            {
                Point<T> point = root; 
                Point<T> current = null;
                bool isExist = false; //Инициализирует переменную isExist как false для проверки существующей точки с таким же значением.
                while (point != null && !isExist) // поиск места для вставки новой точки
                {
                    current = point;
                    if (point.Data.CompareTo(data) == 0) //Проверяет, если значение текущей точки равно значению data.
                        isExist = true;
                    else if (point.Data.CompareTo(data) < 0) //
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
                if (isExist) //Если найдена точка с тем же значением, то прекращает выполнение метода.
                    return;
                Point<T> newPoint = new Point<T>(data); //Создает новую точку newPoint с значением data.
                if (current.Data.CompareTo(data) < 0) 
                    current.Left = newPoint; //Устанавливает левого потомка текущей точки на новую точку newPoint.
                else
                    current.Right = newPoint;
                count++;
            }
        }

        public void TransformToArray(Point<T> point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current); //Вызывается рекурсивно метод TransformToArray для левого поддерева point.
                array[current] = point.Data; //Значение point.Data записывается в массив array по индексу current.
                current++;
                TransformToArray(point.Right, array, ref current); //Вызывается рекурсивно метод TransformToArray для правого поддерева point.
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current); //Вызывается метод TransformToArray для корневого элемента root.

            root = new Point<T>(array[0]); //Создается новый корневой элемент root с помощью первого элемента массива array.
            count = 0;
            for (int i = 0; i < array.Length; i++) 
            {
                AddPoint(array[i]);
            }
            IsFindTree = true;
        }

        public MyTree<T> MadeFromTreeToFindTree(MyTree<T> newTree) 
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current); // Вызывается метод TransformToArray для корневого элемента root.


            for (int i = 0; i < array.Length; i++)
            {
                newTree.AddPoint(array[i]);
            }
            return newTree;
        }


        
        public void Clear()
        {
            Clear(root);
            root = null;
            count = 0;
            IsFindTree = false;
        }

        public void Clear(Point<T> node)
        {
            if (node != null)
            {
                Clear(node.Left);
                Clear(node.Right);
                node.Left = null;
                node.Right = null;
                node.Data = default(T);  // Сбрасываем данные узла
            }
        }

        public void Remove(T data)
        {
            root = Remove(root, data);
        }

        public Point<T> Remove(Point<T> node, T data)
        {
            if (node == null)
            {
                
                return null;
            }

            

            int compare = data.CompareTo(node.Data);

            if (compare < 0)
            {
                node.Left = Remove(node.Left, data);
            }
            else if (compare > 0)
            {
                node.Right = Remove(node.Right, data);
            }
            else if (node.Left == null && node.Right == null)
            {
                node.Data = default;
                return null;
            }
            else if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else // Если у узла есть оба дочерних узла
            {
                Point<T> minNode = FindMin(node.Right); //выбирается наименьший элемент из правого поддерева 
                node.Data = minNode.Data;
                node.Right = Remove(node.Right, minNode.Data);
            }
            return node;
        }

        public Point<T> FindMin(Point<T> node) //находит наименьший элемент в поддереве, начиная с заданной точки.
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public double GetAverageBalance()
        {
            double sumofBalance = 0;
            GetAverageBalanceHelp(root, ref sumofBalance);

            return sumofBalance / count ;
            


        }

        public void GetAverageBalanceHelp(Point<T> node, ref double sumofBalance)
        {
            if (node != null)
            {
                if(node.Data is DebitCard debitCard)
                {
                    sumofBalance += debitCard.Balance;
                }

                GetAverageBalanceHelp(node.Left,ref sumofBalance);
                GetAverageBalanceHelp(node.Right,ref sumofBalance);
            }
        }

        
    }
}
