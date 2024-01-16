﻿using System;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class LoginView : DisplayBase
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}