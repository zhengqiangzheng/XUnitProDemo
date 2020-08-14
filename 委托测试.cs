using System;
using Xunit;

namespace XUnitTestProject1
{
    public delegate int CalCulator(int a, int b);
    public delegate void Del(string message);
    delegate void Delegate1();
    delegate void Delegate2();
    public delegate void ShowMsgHandler(string str);
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }
    }


    public class Î¯ÍÐ²âÊÔ
    {
        public static event ShowMsgHandler ShowMsg;
        // Create a method for a delegate.
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
        [Fact]
        public void Test1()
        {
            CalCulator cal = (int a, int b) => { return a + b; };
            var res2 = cal(1, 2);
            cal += (int a, int b) => { return a - b; };
            var res = cal(1, 2);

            Func<int, int, int> f1 = (int a, int b) => { return a * b; };
            var res3 = f1(2, 3);
            f1 += (int a, int b) => { return a / b; };
            var res4 = f1(10, 2);

        }
        [Fact]
        public void Test2()
        {
            var obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;
            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;
            int invocationCount = allMethodsDelegate.GetInvocationList().GetLength(0);
            allMethodsDelegate("123");

            var x = ShowMsg == null;
            ShowMsg += ShowName;
            ShowMsg("hahahha");
            var y = ShowMsg == null;


            //Delegate1 d;
            //Delegate2 e; System.Delegate f;
            // Console.WriteLine(d==e);
            //Console.WriteLine(d==f);




        }

        internal static void ShowName(string str)
        {
            Console.WriteLine("My Name is {0}", str);
        }

    }
}
