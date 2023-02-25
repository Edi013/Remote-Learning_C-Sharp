﻿
namespace iQuest.VendingMachine.Business
{
    public interface IPaymentAlgorithm
    {
        public string Name { get; }

        public void Run(float price);
    }
}
