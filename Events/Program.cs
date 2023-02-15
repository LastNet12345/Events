namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete = AfterComplete;
           // transaction.TransactionComplete += AfterComplete2;
           transaction.StartTrancation();
        }

        private static void AfterComplete()
        {
            Console.WriteLine("Completed");
        } 
        
        //private static void AfterComplete2()
        //{
        //    Console.WriteLine("Completed 2");
        //}
    }

    public delegate void Notify();

    public class Transaction
    {
        public Notify TransactionComplete { get; set; }
        public void StartTrancation()
        {
            //Do Something

            OnTransactionComplete();
        }

        protected virtual void OnTransactionComplete()
        {
            TransactionComplete?.Invoke();
        }
    }
}