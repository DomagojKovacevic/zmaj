using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
//           int initialSize;
//           Console.WriteLine("Insert array size: ");
//           initialSize = Convert.ToInt32(Console.ReadLine());
//           IntegerList ListDefault = new IntegerList();
//           IntegerList ListUser = new IntegerList(initialSize);
//
//           
//           ListUser.ListExample(ListUser);
//
           IGenericList<string> stringList = new GenericList<string>();
           stringList.Add(" Hello ");
           stringList.Add(" World ");
           stringList.Add("!");
           foreach (string value in stringList)
           {
               Console.WriteLine(value);
           }


        }
    }
}


