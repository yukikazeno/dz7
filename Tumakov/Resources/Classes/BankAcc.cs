namespace Tumakov
{
    public class BankAcc
    {
        private static ulong _accountCounter = 1000000000000000;
        private readonly ulong _accNumber;
        private AccType _accType;
        private decimal _balance;

        public ulong AccNumber
        {
            get { return _accNumber; }
        }

        public AccType AccType
        {
            get { return _accType; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public BankAcc() { }
        public BankAcc(ulong? AccNumber, AccType AccType, decimal Balance)
        {
            _accNumber = AccNumber ?? GetAutoNumber();
            _accType = AccType;
            _balance = Balance;
        }

        private static ulong GetAutoNumber()
        {
            _accountCounter++;
            return _accountCounter;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Account Number: {_accNumber} \nAccount Type: {_accType} \nBalance: {_balance} руб.");
        }

        public void PutMoney(decimal amount)
        {
            _balance += amount;
        }

        public void TakeMoney(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
        }

        public void TransferMoney(BankAcc targetAccount, decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                targetAccount.PutMoney(amount);
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете для перевода.");
            }
        }
    }
}