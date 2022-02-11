using System;

namespace Deptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var deptorApp = new DeptorApp();
            deptorApp.IntroduceDeptorApp();
            deptorApp.AskForAction();
        }
    }
}