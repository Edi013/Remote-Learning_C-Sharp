

namespace iQuest.VendingMachine.Business
{
    public class LookUseCase : IUseCase
    {
        private readonly IShelfView view;
        private readonly IProductAndSalesUnitOfWork productAndSalesUnitOfWork;

        public LookUseCase(IShelfView view, IProductAndSalesUnitOfWork productAndSalesUnitOfWork)
        {
            this.view = view;
            this.productAndSalesUnitOfWork = productAndSalesUnitOfWork;
        }

        public void Execute()
        {
            view.DisplayProducts(productAndSalesUnitOfWork.ProductRepository.GetProducts());
        }
    }
}
