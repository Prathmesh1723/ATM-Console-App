using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

public class accountHolder{
    String cardNo, firstName, lastName;
    int pin;
    double balance;

    public accountHolder(String cardNo, int pin, String firstName, String lastName, double balance){
        this.cardNo = cardNo;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum(){
        return cardNo;
    }

    public int getPin(){
        return pin;
    }

    public String getFirstnName(){
        return firstName;
    }

    public String getLastName(){
        return lastName;
    }

    public double getBalance(){
        return balance;
    }

    public void setNum(String newCardNo){
        cardNo = newCardNo;
    }

    public void setPin(int newPin){
        pin = newPin;
    }

    public void setFirstName(String newFirstName){
        firstName = newFirstName;
    }

    public void setLastName(String newLastName){
        lastName = newLastName;
    }

    public void setBalance(double newBalance){
        balance = newBalance;
    }

    public static void Main(String[] args){
        void printOptions(){
            Console.WriteLine("Please choose from one of the follwing options....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Create Account");
            Console.WriteLine("5. Exit");
        }

        void deposit(accountHolder accountUser){
             Console.WriteLine("Please enter the amount you wish to deposit :");
             double deposit = double.Parse(Console.ReadLine());
             accountUser.setBalance(accountUser.getBalance() + deposit);
             Console.WriteLine("Thank you for depositing your money! Your new account Balance is: " + accountUser.getBalance());
        }

        void withdraw(accountHolder accountUser){
            Console.WriteLine("Enter the amount of money $$ to withdraw : ");
            double withdrawal = Double.Parse(Console.ReadLine());

            //Check if the use r has enough money
            if(accountUser.getBalance() < withdrawal){
                Console.WriteLine("Insufficient Balance :( ");
            }
            else
            {
                accountUser.setBalance(accountUser.getBalance() -  withdrawal);
                Console.WriteLine("You're good to go! Thank you :) ");
            }
    }

    void balance(accountHolder accountUser){
        Console.WriteLine("Get balance in which currency : ");
        string currency = Console.ReadLine();
        double rate = Decimal.ToDouble(GetExchangeRate(currency));
        if(currency == "USD"){
            Console.WriteLine("Current Balance : " + accountUser.getBalance() + " USD");
        }else{
            Console.WriteLine("Current Balance : " + Math.Round((rate*accountUser.getBalance()),2) + " " + currency);
        }
    }

    decimal GetExchangeRate(string currency)
    {
        // Replace 'YOUR_API_KEY' with your actual Open Exchange Rates API key
        string apiKey = "c40122d3288749ffbc0c423b19cc8b08";

        // Specify the base currency and target currency you want to get the exchange rate for
        string baseCurrency = "USD";
        string targetCurrency = "EUR";

        // Construct the API URL with the base currency, target currency, and API key
        string apiUrl = $"https://openexchangerates.org/api/latest.json?base={baseCurrency}&symbols={currency}&app_id={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Send the HTTP GET request to the API
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = response.Content.ReadAsStringAsync().Result;

                    // Parse the JSON response into a JObject
                    var jsonData = JsonDocument.Parse(responseContent);

                    // Extract the exchange rate from the JSON data
                    decimal exchangeRate = jsonData.RootElement
                        .GetProperty("rates")
                        .GetProperty(currency)
                        .GetDecimal();

                    // Print the exchange rate
                    Console.WriteLine($"1 {baseCurrency} = {exchangeRate} {currency}");
                    return exchangeRate;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve exchange rate. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return 0;
        }
    }

    //Account Holders list or Testing
    List<accountHolder> accountHolders = new List<accountHolder>();
    accountHolders.Add(new accountHolder("4567890123334", 4341, "Jack", "Harlow", 250.32));
    accountHolders.Add(new accountHolder("1234567890123", 1111, "John", "Doe", 100.50));
    accountHolders.Add(new accountHolder("9876543210987", 2222, "Jane", "Smith", 500.75));
    accountHolders.Add(new accountHolder("4561237890456", 3333, "Mike", "Johnson", 750.20));
    accountHolders.Add(new accountHolder("7890123456789", 4444, "Emily", "Davis", 300.10));
    accountHolders.Add(new accountHolder("6543210987654", 5555, "Alex", "Anderson", 1000.00));

    void createAccount(List<accountHolder> accountHolders){
        Console.WriteLine("Please enter the following information to create a new account:");

        Console.WriteLine("Card Number (12 digits): ");
        string cardNo = "";
        while (true)
        {
            cardNo = Console.ReadLine();
            if (cardNo.Length != 12)
            {
                Console.WriteLine("Invalid card number. Please enter a 12-digit card number:");
            }
            else if (!cardNo.All(char.IsDigit))
            {
                Console.WriteLine("Invalid card number. Please enter a numeric value:");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("PIN (4 digits): ");
        int pin = 0;
        while (true)
        {
            string pinString = Console.ReadLine();
            if (pinString.Length != 4)
            {
                Console.WriteLine("Invalid PIN. Please enter a 4-digit PIN:");
            }
            else if (!pinString.All(char.IsDigit))
            {
                Console.WriteLine("Invalid PIN. Please enter a numeric value:");
            }
            else
            {
                pin = int.Parse(pinString);
                break;
            }
        }

        Console.WriteLine("First Name: ");
        string firstName = "";
        while (true)
        {
            firstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                Console.WriteLine("Invalid first name. Please enter a non-empty value:");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("Last Name: ");
        string lastName = "";
        while (true)
        {
            lastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Invalid last name. Please enter a non-empty value:");
            }
            else
            {
                break;
            }
    }

    Console.WriteLine("Initial Balance: ");
    double initialBalance = double.Parse(Console.ReadLine());

    accountHolder newAccount = new accountHolder(cardNo, pin, firstName, lastName, initialBalance);
    accountHolders.Add(newAccount);

    Console.WriteLine("Account created successfully!");
}

    
    Console.WriteLine("Welcome to My ATM");
    Console.WriteLine("Please insert your debit card: ");
    String debitCardNum = "";
    accountHolder accountUser;

    while (true)
    {
        try
        {
            debitCardNum = Console.ReadLine();
            //check if the Debit card Number exists in Database
            accountUser = accountHolders.FirstOrDefault(a => a.cardNo == debitCardNum);
            if(accountUser != null){
                break;
            }
            else{
                Console.WriteLine("Card not recognised.Please try again");
            }
        }
        catch
        {
            Console.WriteLine("Card not recognised.Please try again");
        }
    }


        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if(accountUser.getPin() == userPin){
                    break;
                }
                else{
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
        }
        catch{
            Console.WriteLine("incorrect pin. Please try again");
        }
        }

        Console.WriteLine("Welcome " + accountUser.getFirstnName() + " :)");
        int option = 0;
        do{
            printOptions();
            try{
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(accountUser); }
            else if(option == 2) { withdraw(accountUser); }
            else if(option == 3) { balance(accountUser); }
            else if(option == 4) { createAccount(accountHolders); }
            else if(option == 5) { break; }
            else { option = 0; }
        }while(option != 5);
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}

