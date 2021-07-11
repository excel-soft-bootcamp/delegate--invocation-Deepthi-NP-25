using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokeDelegate
{
    class Program
    {

        static double Calculate(int x, double y) { return x + y; }

        void Update(int newNumber) { System.Console.WriteLine(newNumber); }

        void Delete(string key) { }

        void M1() { }
        void M2(string data) { }
        int M3(int x)
        {
            return x;
        }
        bool M4(string data, string newData)
        {
            return true;
        }

        public static void FunctionsAsAnArguments(Action obj, Action<string> obj2, Func<int, int> obj3, Func<string, string, bool> obj4, Func<int, double, double> obj7, Action<int> obj8)
        {
            //Invoke Delegate objects
            obj.Invoke();
            obj2.Invoke("data1 data2");
            int intValue = obj3.Invoke(7);
            bool boolValue = obj4.Invoke("data1", "data2");
            double doubleValue = obj7.Invoke(3, 4.5);
            obj8.Invoke(2);

            Console.WriteLine(intValue);
            Console.WriteLine(boolValue);
            Console.WriteLine(doubleValue);



        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            Func<int, double, double> M1ptr = new Func<int, double, double>(Program.Calculate);
            Action<int> M2ptr = new Action<int>(obj.Update);
            Action<string> M3ptr = new Action<string>(obj.Delete);
            Action action = new Action(obj.M1);
            Action<string> M4ptr = new Action<string>(obj.M2);
            Func<int, int> func2 = new Func<int, int>(obj.M3);
            Func<string, string, bool> func3 = new Func<string, string, bool>(obj.M4);

            FunctionsAsAnArguments(action, M4ptr, func2, func3, M1ptr, M2ptr);
        }
    }
}