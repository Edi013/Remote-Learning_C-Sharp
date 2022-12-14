using iQuest.VendingMachine.DataLayer;
using iQuest.VendingMachine.PresentationLayer;

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly ProductRepository productRepository;
        private readonly BuyView buyView;

        public string Name => "Buy";

        public string Description => "You will buy something.";

        public bool CanExecute => productRepository.GetAll().Any();

        public BuyUseCase(ProductRepository products, BuyView buyView)
        {
            this.productRepository = products;
            this.buyView = buyView;
        }            

        public void Execute()
        { 
            int columnNumber;

            if((columnNumber = buyView.RequestProduct()) == -1)
            {
                return;
            }

            bool found = false;
            foreach(Product product in productRepository.GetAll() )
            {
                if(product.ColumnId == columnNumber)
                {
                    if(product.Quantity > 0)
                    {
                        found = true;
                        //pay
                        product.Quantity--;
                        buyView.DispenseProduct(product.Name);
                    }
                }
                if(found)
                  break;
            }
            if(!found)
                buyView.DisplayProductNotAvailabel();
        }
    }
}