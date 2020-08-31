using System;
using System.Linq;

namespace coredb
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var db = new MyWebsiteDBContext();
            var ret = from c in db.TMember
                      select c;

            foreach (var item in ret)
            {
                Console.WriteLine($"{item.FName} - {item.FAge} - {item.FSex} ");
            }
        }
    }
}
