using iQuest.VendingMachine.Business.Exceptions;

namespace iQuest.VendingMachine.Business
{
    public class CashPayment : IPaymentAlgorithm
    {

        private readonly ICashPaymentTerminal terminal;

        public string Name => "Cash";
        
        public CashPayment(ICashPaymentTerminal terminal) 
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
            catch(InvalidPaymentInputException)
            {
                terminal.ReleaseMoney(sumPayed);
                throw;
            }
            catch(CancelException)
            {
                terminal.ReleaseMoney(sumPayed);
                throw;
            }

            if(price != sumPayed)
                terminal.GiveBackChange(sumPayed - price);
        }
    }
}
