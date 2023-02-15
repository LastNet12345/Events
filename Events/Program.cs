namespace Events
{
#nullable disable
    internal class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
           transaction.StartTrancation(true);
        }

        private static void AfterComplete(object sender, TransactionEventArgs eventArgs)
        {
            Console.WriteLine($"Sender: {sender}, Completed with message: {eventArgs.Message}, Status: {eventArgs.IsOk}");
        } 
    }

    public class Transaction
    {
        public event EventHandler<TransactionEventArgs> TransactionComplete;
        public void StartTrancation(bool ok)
        {
            //Do Something
            if (ok)
            {

               OnTransactionComplete("OK", true);
            }
            else
            {

               OnTransactionComplete("Failed", false);
            }

        }

        protected virtual void OnTransactionComplete(string message, bool ok)
        {
            var transEventArgs = new TransactionEventArgs
            {
                Message = message,
                IsOk = ok
            };

            TransactionComplete?.Invoke(this, transEventArgs);
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool IsOk { get; set; }
    }
}