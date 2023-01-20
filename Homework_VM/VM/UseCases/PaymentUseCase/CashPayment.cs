﻿using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class CashPayment : IPaymentAlgorithm
    {

        private readonly CashPaymentTerminal terminal;

        public string Name => "Cash";
        
        public CashPayment(CashPaymentTerminal terminal) 
        {
            this.terminal = terminal;
        }

        public void Run(float price)
        {
            float sumPayed = 0;
            try
            {
                while(price > sumPayed)
                {
                    float input = terminal.AskForMoney(price - sumPayed);

                    sumPayed += input;
                }

            }
            catch(InvalidInputWhilePayingException e)
            {
                terminal.ReleaseMoney(sumPayed);
                throw e;
            }

            if(price != sumPayed)
                terminal.GiveBackChange(sumPayed - price);
        }
    }
}
