using System;
using System.Net.Http.Headers;

public class account
{
    public double balance = 0;           //adding the fields to the class
    public string acc_no;
    public int pin;
    public void summary()                                   //method to get the details of a particular account
    {
        Console.WriteLine("your account number is :" + this.acc_no);
        Console.WriteLine("your balance is : " + this.balance);
    }
    public void transfer()                                  //method to transfer money to another account.
    {
        Console.Write("\n\n                                       ");
        Console.WriteLine("===============================");
        Console.Write("                                       ");
        Console.WriteLine("**** MONEY TRANSFER SYSTEM ****");
        Console.Write("                                       ");
        Console.WriteLine("===============================");
        this.summary();                                               //firstly getting the details of the account.
        Console.Write("\nEnter the account number to transfer: ");
        string tra = Console.ReadLine();
        Console.Write("\nPlease enter the amount to be transferred: ");
        int amount = Convert.ToInt32(Console.ReadLine());                 //taking the money input to be transferred.
        if (amount > this.balance)                                     //checking whether the input money is not greater 
        { Console.WriteLine("sorry!! you dont have this much money.");                 //than the money in account.
            return;
        }
        this.balance -= amount;                                             //reducing the money from the account
        this.balance_enquiry();
        Console.WriteLine("\nthe money is tranferred successfully and now you can safely remove your atm card!!");
    }
    public void cash_deposit()                                             //method to deposit the money into the account
    {
        Console.Write("\n\n                                       ");
        Console.WriteLine("=============================");
        Console.Write("                                       ");
        Console.WriteLine("**** CASH DEPOSIT SYSTEM ****");
        Console.Write("                                       ");
        Console.WriteLine("=============================");
        this.summary();
        Console.Write("\nPlease enter the amount to be credited: ");         //taking the money input to be credited
        int amount = Convert.ToInt32(Console.ReadLine());
        this.balance += amount;                                              //adding the money into the account
        this.balance_enquiry();
        Console.WriteLine("\nyour bank account is credited successfully and now you can safely remove your atm card!!");
    }
    public void balance_enquiry()                                      //method to check the current balance in account
    {
        Console.Write("\nyour current request is processing");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.WriteLine(".");
        Console.WriteLine("The current balance is : " + this.balance);     //showing the balance
    }
    public void cash_withdrawal()                                         //method to withdraw the cash from the account
    {
        Console.Write("\n\n                                       ");
        Console.WriteLine("================================");
        Console.Write("                                       ");
        Console.WriteLine("**** CASH WITHDRAWAL SYSTEM ****");
        Console.Write("                                       ");
        Console.WriteLine("================================");
        this.summary();
        Console.Write("\nPlease enter the amount for withdrawal : ");       //taking the input money to withdraw.
        int amount = Convert.ToInt32(Console.ReadLine());
        if (amount > this.balance)                                         //checking whether the input money is not greater
        { Console.WriteLine("sorry!! you dont have this much money.");             //than the money in the account
            return;
        }
        this.balance-=amount;                                               //reducing the amount from the account
        this.balance_enquiry();
        Console.WriteLine("Please take the cash and you can safely remove your atm card!!");
    }
    public account(double balance, string acc_no, int pin)   //parametrized constructor of the class
    {
        this.balance = balance;
        this.acc_no = acc_no;
        this.pin = pin;
    }
}
class atm_software                                           //main class initiated
{
    public static void Main(string[] args)                    //main function started
    {
        char ch = 'y';
            account[] arr = new account[] { new account(1000.0D,"nbi1234",3456),      //putting data in the database
                                        new account(2000.0D,"nbi9599",1234),
                                        new account(9934.9D,"nbi9385",2345)  };
        while (ch == 'y')                                     //while loop to give option of inserting the atm card again 
        {
            Console.BackgroundColor = ConsoleColor.Cyan;      //to change the background colour to cyan
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;     //to change the text colour to black
            Console.Write("\n\n                                       ");
            Console.WriteLine("========================================================");
            Console.Write("                                       ");
            Console.WriteLine("**** Hello! welcome to National Bank Of India (NBI) ****");
            Console.Write("                                       ");
            Console.WriteLine("========================================================");
            Console.WriteLine("\nplease insert your card and press enter key");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n\nplease do not remove your card.\nLeave your card inserted during the entire transaction.");
            Console.Write("\nPlease enter your pin : ");
            int pin = Convert.ToInt32(Console.ReadLine());              //taking the atm pin to verify
            int p = -1;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j].pin == pin)
                    p = j;
            }
            if (p == -1)
            {
                Console.WriteLine("sorry!! wrong pin , please take your card");
                return;
            }
            Console.Clear();
            Console.WriteLine("\n\nservices provided are :");             //listing the services
            Console.WriteLine("\n[1] TRANFER MONEY\n[2] CASH WITHDRAWAL\n[3] BALANCE ENQUIRY\n[4] CASH DEPOSIT");
            Console.Write("\nwhat would you like to perform (1,2,3,4): ");
            int i = Convert.ToInt32(Console.ReadLine());                    //letting the user to choose one of the services
            Console.Clear();
            switch (i)                               //using switch case to call service method according to user's choice
            {
                case 1:
                    arr[p].transfer();
                    break;
                case 2:
                    arr[p].cash_withdrawal();
                    break;
                case 3:
                    arr[p].balance_enquiry();
                    break;
                case 4:
                    arr[p].cash_deposit();
                    break;
                default:
                    Console.WriteLine("wrong input , please take your card!! ");
                    break;
            }
            Console.Write("\n\n\n\nwant to insert the card and use our service again (y/n): ");
            ch = Convert.ToChar(Console.ReadLine());                           //if the user wants to use service again
        }
    }
}