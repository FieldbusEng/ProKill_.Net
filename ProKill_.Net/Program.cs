using System;


namespace ProKill_.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            //[0] Proc Name, [1] TimeAllowed, [2] Scan Freq
            if (string.IsNullOrEmpty(args[0]) || string.IsNullOrEmpty(args[1]) || string.IsNullOrEmpty(args[2]))
            {
                Console.WriteLine("Not correct input");
                Environment.Exit(0);
            }
            string inputName = args[0];
            int timeAllowed = Convert.ToInt32(args[1]);
            int timeFreq = Convert.ToInt32(args[2]);

            Console.WriteLine("App Process Care");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("You looking for process Name: {0} it will be closed in: {1} " + inputName, timeAllowed);

            Processes instProc = new Processes();

             int result = instProc.IfProcExist(inputName);


            Console.ReadKey();
        }
    }
}
