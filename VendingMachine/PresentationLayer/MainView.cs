using System;
using System.Collections.Generic;

namespace Nagarro.VendingMachine.PresentationLayer
{
    internal class MainView : DisplayBase
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public IUseCase ChooseCommand(IEnumerable<IUseCase> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }

        public void DisplayError(Exception exception)
        {
            Console.WriteLine();
            Display(exception.Message, ConsoleColor.Red);
            Console.WriteLine();
        }
    }
}