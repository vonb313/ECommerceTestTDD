using System.Text.RegularExpressions;

namespace ECommerce;

public class UserInputValidator
{
    public bool IsValidUsername(string username) //Metoden för att validera användarnamn.
    {
        //Reguljärt uttryck som sätter krav på 5 till 20 tecken och att de enbart får vara alfanumeriska.
        return Regex.IsMatch(username, @"^[a-zA-Z0-9]{5,20}$");
    }

    public bool IsValidPassword(string password)//Metoden för att validera lösenord.
    {
        //Krav på att lösenordet är minst 8 tecken och innehåller minst 1 specialtecken.
        return password.Length >= 8 && Regex.IsMatch(password, @"[!@#$%^&*]");
    }

    public bool IsValidEmail(string email)//Metoden för att validera epostadress.
    {
        //Krav på att epostadressen matchar ett giltigt format.
        return Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    }
}
