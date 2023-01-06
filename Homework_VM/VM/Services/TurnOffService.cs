namespace iQuest.VendingMachine.Services
{
    internal class TurnOffService : ITurnOffService
    {
        private bool status;

        public bool Status { get => status; private set => status = value; }

        public TurnOffService()
        {
            Status = false;
        }

        public void TurnOff()
        {
            Status = true;
        }
    }
}
