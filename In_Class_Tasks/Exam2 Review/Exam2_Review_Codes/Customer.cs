using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Customer
{
    // ============= Fields =============
    private int _customerId;
    private string _name;
    private string _phone;
    private string _email;
    private string _address;

    // ============= Properties =============
    public int CustomerId
    {
        get { return _customerId; }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (value is null || value.Equals(""))
            {
                Console.WriteLine("Name cannot be empty.");
            }
            else
                _name = value;
        }
    }

    public string Phone
    {
        get { return _phone; }
        set { _phone = value ?? ""; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value ?? ""; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value ?? ""; }
    }

    // ============= Constructors =============
    public Customer()
    {
        _customerId = 0;
        _name = "Not Provided";
        _phone = "Not Provided";
        _email = "Not Provided";
        _address = "Not Provided";
    }

    public Customer(int id, string name, string phone, string email, string address)
    {
        _customerId = id;
        _name = name;
        _phone = phone;
        _email = email;
        _address = address;
    }

    // ============= Methods =============
    public void DisplayInfo()
    {
        Console.WriteLine($"Customer ID: {_customerId}\tName: {_name}\tPhone: {_phone}\tEmail: {_email}\tAddress: {_address}");
    }
}