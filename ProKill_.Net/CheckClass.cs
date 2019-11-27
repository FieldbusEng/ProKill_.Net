using System;
using System.Text.RegularExpressions;

namespace ProKill_.Net
{
    class CheckClass
    {

        public string[] methodInput()
        {
            Console.WriteLine("Please type correct: [string Process Name] [int Time Allowed(minutes)] [int Scan Time(minutes)]");
            string input = Console.ReadLine();
            if (input == "exit")
            {
                Environment.Exit(0);
            }
            
            String[] inputSplit = input.Split(new Char[] { ' ', ',', '.', ':', '\t' });
            return inputSplit;
        }

        public (string, string, string) methodCheck(string[] _args)
        {
            // Log instance
            Logger log = new Logger();

            // check for quantity of elements
            int count = 0;
            // check if string[] has 3 items
            if (_args.Length == 3) // !string.IsNullOrEmpty(_args[0]) || !string.IsNullOrEmpty(_args[1]) || !string.IsNullOrEmpty(_args[2])
            {

                log.methodLogger(" Success - methodCheck - check if string[] has 3 items ");
                // check if its only 3 strings
                foreach (string item in _args) count++;
                if (count == 3)
                {
                    //Log
                    log.methodLogger(" Success - methodCheck - check if its only 3 strings ");

                    // check if 2 last arguments not consist letters 
                    int errorCounter1 = 0;
                    int errorCounter2 = 0;
                    errorCounter1 = Regex.Matches(_args[1], @"[a-zA-Z]").Count;
                    errorCounter2 = Regex.Matches(_args[1], @"[a-zA-Z]").Count;

                    // check if possible to convert to Int32
                    try
                    {
                        Convert.ToInt32(_args[1]);
                        Convert.ToInt32(_args[2]);
                    }
                    catch (Exception e)
                    {
                        //Log
                        log.methodLogger(" Exception in  - methodCheck - convert to Int32: " + e.ToString());
                        return methodCheck(methodInput());
                    }


                    if (errorCounter1 == 0 && errorCounter2 == 0)
                    {
                        //Log
                        log.methodLogger(" Success - methodCheck - check if 2 last arguments not consist letters ");

                        // check if 2 timers > 0
                        if (Convert.ToInt32(_args[1]) > 0 && Convert.ToInt32(_args[2]) > 0)
                        {
                            // check if 3d arg is multiple to 2d arg
                            if ((Convert.ToInt32(_args[1]) % Convert.ToInt32(_args[2])) == 0)
                            {
                                //Log
                                log.methodLogger(" Success - methodCheck - check if if 3d arg is multiple to 2d arg ");
                                return (_args[0], _args[1], _args[2]);

                            }
                            else
                            {
                                //Log
                                log.methodLogger(" Failed - methodCheck - check if if 3d arg is multiple to 2d arg ");
                                return methodCheck(methodInput());
                            }
                        }
                        else
                        {
                            //Log
                            log.methodLogger(" Failed - methodCheck - check if 2 timers > 0 ");
                            return methodCheck(methodInput());
                        }


                    }
                    else
                    {
                        //Log
                        log.methodLogger(" Failed - methodCheck - check if 2 last arguments not consist letters ");
                        return methodCheck(methodInput());
                    }


                }
                else
                {
                    //Log

                    log.methodLogger(" Failed - methodCheck - check if its only 3 strings ");
                    return methodCheck(methodInput());
                }

            }
            else
            {
                // Log
                log.methodLogger(" Failed - methodCheck - check if string[] has 3 items ");
                return methodCheck(methodInput());

            }


        }
    }
}
