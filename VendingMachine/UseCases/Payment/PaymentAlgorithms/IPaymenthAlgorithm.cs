namespace Nagarro.VendingMachine.UseCases.Payment.PaymentAlgorithms
{
    public interface IPaymenthAlgorithm
    {
        public string Name { get; set; }
        public void Run(float price);
    }
}
