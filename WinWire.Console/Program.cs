// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using WinWire.Console.BubbleSort;
using WinWire.Console.ConstructorInformationProgram;
using WinWire.Console.Linq;
using WinWire.Console.SubArray;

namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            TailorValidator validator = new TailorValidator();
            Console.WriteLine(validator.DateInfo());
            Console.WriteLine(validator.ConstructorInformation());

            Console.WriteLine("Sorting Program.....");
            int[] arr = { 12, 9, 45, 78, 54, 65, 80, 13, 21, 34, 51, 60 };

            // {9, 12, 13, 21, 34, 45, 51, 54, 60, 65, 78, 80}
            var result = SortingProgram.BubbleSort_ForLoop(arr);
            foreach (var sort in result)
            {
                Console.WriteLine("BubbleSort ForLoop Result ....." + sort);
            }

            var whileResult = SortingProgram.BubbleSort_WhileLoop(arr);
            foreach (var sort in whileResult)
            {
                Console.WriteLine("BubbleSort WhileLoop Result ....." + sort);
            }

            // Cross Join in Linq
            var crossJoinResult = JoinQueries.CrossJoin();
            foreach (var join in crossJoinResult)
                Console.WriteLine($"{join.Color}, {join.Item}");

            // Sum of Sub Array
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            ArrayQuery.MaxSubArray(nums);

            // Single Responsibility Priciple
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);

            StatementPrinter printer = new StatementPrinter();
            printer.Print(johnsAccount);

            Console.ReadLine();
        }
    }

    #region Single Responsibility Priciple

    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public List<string> Transactions = new List<string>();
        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }
        public void Withdraw(double amount)
        {
            Balance -= amount;
            Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }
    }
    public class StatementPrinter
    {
        public void Print(BankAccount account)
        {
            Console.WriteLine($"Statement for Account: {account.AccountNumber}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }

    #endregion
}