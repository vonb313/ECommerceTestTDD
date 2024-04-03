namespace ECommerce;

public class UserRegistrationService
{
    private List<string> registeredUsers; //Privat lista med registrerade användarnamn.

    public UserRegistrationService()
    {
        registeredUsers = new List<string>();//Skapar en instans av en lista när en UserRegistrationService skapas.
    }

    public bool IsUniqueUsername(string username)
    {
        return !registeredUsers.Contains(username); //Kontrollerar användarnamnet redan finns i listan över registrerade användare.
    }

    public string RegisterUser(string username, string email, string password)
    {
        var validator = new UserInputValidator(); //Skapar en instans av UserInputValidator för att validera användarinformation

        if (!validator.IsValidUsername(username)) //Kontrollerar om användarnamnet uppfyller kraven för ett giltigt format.
            return "Invalid username format.";//Returnerar felmeddelande om ogiltigt format.

        if (!validator.IsValidPassword(password))//Kontrollerar om lösenordet uppfyller kraven för ett giltigt format.
            return "Invalid password format.";//Returnerar felmeddelande om ogiltigt format.

        if (!validator.IsValidEmail(email))//Kontrollerar om e-post uppfyller kraven för ett giltigt format.
            return "Invalid email format.";//Returnerar felmeddelande om ogiltigt format.

        if (!IsUniqueUsername(username))//Kontrollerar om användarnamnet redan finns i systemet.
            return "Username already taken.";//Returnerar felmeddelande om användarnamn redan finns.

        registeredUsers.Add(username);//Lägger till användarnamnet i listan över registrerade användare.
        return $"User '{username}' successfully registered.";//Returnerar ett bekräftelsemeddelande om användaren har registrerats.
    }
}
