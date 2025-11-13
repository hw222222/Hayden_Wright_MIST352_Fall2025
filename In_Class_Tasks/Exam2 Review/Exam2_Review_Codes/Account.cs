using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    // ============= Fields =============
    private int _id;
    private string _type;
    private DateOnly _openDate;
    private Customer _customer;
    private double _balance;

    // ============= Properties =============
    public int Id
    {
        get { return _id; }
    }

    public string Type
    {
        get { return _type; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine("Type can not be empty. Try again");
            }
            else
                _type = value;
        }
    }

    public DateOnly OpenDate
    {
        get { return _openDate; }
    }

    public Customer Customer
    {
        get { return _customer; }
        set
        {
            if (value == null)
            {
                Console.WriteLine("Customer can not be null. Try again");
            }
            else
                _customer = value;
        }
    }

    public double Balance
    {
        get { return _balance; }
    }

    // ============= Constructors =============
    public Account(int id)
    {
        _id = id;
        _type = "Not Provided";
        _openDate = DateOnly.FromDateTime(DateTime.Now);
        _customer = null;
        _balance = 0.0;
    }

    public Account(int id, string type)
        : this(id)
    {
        _type = type;
    }

    public Account(Customer customer)
    {
        _id = 0;
        _type = "Not Provided";
        _openDate = DateOnly.FromDateTime(DateTime.Now);
        _customer = customer;
        _balance = 0.0;
    }

    // ============= Methods =============
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be positive. Try again");
            return;
        }
        _balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount must be positive. Try again");
            return false;
        }
        if (amount > _balance)
        {
            Console.WriteLine("Insufficient funds. Try again");
            return false;
        }

        _balance -= amount;
        return true;
    }

    public void AssignCustomer(Customer c)
    {
        if (c == null)
        {
            Console.WriteLine("Customer can not be null. Try again");
            return;
        }

        _customer = c;
    }

    public void Close()
    {
        _balance = 0.0;
        _type = "Closed";
        _customer = null;
    }

    public void DisplayInfo()
    {
        string custText;

        if (_customer != null)
            custText = $"Customer ID: {_customer.CustomerId}";
        else
            custText = "Customer ID: Not Provided";

        Console.WriteLine($"Account ID: {_id}\tType: {_type}\tOpen Date: {_openDate}\tBalance: {_balance}\t{custText}");
    }
}