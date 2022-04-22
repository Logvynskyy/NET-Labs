using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<string> list = new MyLinkedList<string>();
            list.insertion += (item) => { Console.WriteLine("Item, present in the list - " + item.ToString()); };
            list.deletion += (item) => { Console.WriteLine("Item, deleted from the list - " + item.ToString()); };

            try
            {
                list.Add("dasdas");
                list.Add("tetete");
                list.Add("1");

                //list.Add(null);//  To test exceptions
                Console.WriteLine(list);

                list.Contains("1");

                list.Remove("F");

                list.Remove("tetete");
                list.Clear();

                Console.WriteLine(list);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Program ended with an exception!");
            }
        }
    }
}
