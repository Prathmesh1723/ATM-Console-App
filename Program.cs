Using System;

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
}



