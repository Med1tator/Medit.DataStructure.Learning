using System;

namespace _001.LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1); arrayList.Add(2); arrayList.Add(3); arrayList.Add(4); arrayList.Add(5); arrayList.Add(6);

            //arrayList.RemoveAt(1);arrayList.RemoveAt(1);

            //for (int i = 0; i < arrayList.Size; i++)
            //{
            //    Console.WriteLine(arrayList.Get(i));
            //}

            //ArrayList
            SingleLinkedList singleLinkedList = new SingleLinkedList();
            singleLinkedList.Add(1); singleLinkedList.Add(2); singleLinkedList.Add(3); singleLinkedList.Add(4); singleLinkedList.Add(5); singleLinkedList.Add(6);

            singleLinkedList.RemoveAt(1); singleLinkedList.RemoveAt(1);

            for (int i = 0; i < singleLinkedList.Size; i++)
            {
                Console.WriteLine(singleLinkedList.Get(i));
            }

            Console.WriteLine("Hello World!");
        }
    }
}
