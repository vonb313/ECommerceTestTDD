namespace ECommerce.Tests;

[TestClass]
public class UserRegistrationServiceTests
{
    [TestMethod] //Testfall när användarnamnet är unikt. Förväntar sig Sant som resultat.
    public void IsUniqueUsername_NewUsername_ReturnsTrue()
    {
        //Arrange
        var service = new UserRegistrationService();
        string username = "anewuser"; //Unikt användarnamn.

        //Act
        bool isUnique = service.IsUniqueUsername(username);//Anropar metoden med unikt användarnamn.

        //Assert
        Assert.IsTrue(isUnique);//Kontrollerar om det är sant att användarnamnet är unikt.
    }

    [TestMethod] //Testfall för icke unikt användarnamn. Förväntar sig falskt som resultat.
    public void IsUniqueUsername_ExistingUsername_ReturnsFalse()
    {
        //Arrange
        var service = new UserRegistrationService();
        string username = "existinguser"; //Definiera ett användarnamn.
        service.RegisterUser(username, "mail@mail.com", "Password123!"); //Registrera en användare med det befintliga anänvarnamnet.

        //Act
        bool isUnique = service.IsUniqueUsername(username);//Anropar metoden med befintliga använarnamnet.

        //Assert
        Assert.IsFalse(isUnique);//Kontrollerar om resultatet är falskt och om användarnamnet inte är unikt.
    }

    [TestMethod]//Testfall för registrering av giltig användare. Förväntar sig ett bekräftelsemeddelande.
    public void RegisterUser_ValidInformation_ReturnsConfirmationMessage()
    {
        //Arrange
        var service = new UserRegistrationService();
        string username = "validUser123";//Giltigt användarnamn.
        string email =  "valid@mail.com";//Giltig e-post.
        string password = "Password123!";//Gilgit lösenord.

        //Act
        string confirmationMessage = service.RegisterUser(username, email, password);//Registrerar användaren med giltig information.

        //Assert
        Assert.IsNotNull(confirmationMessage);//Kontrollerar att ett bekräftelse meddelande returneras.
        Assert.IsTrue(confirmationMessage.Contains(username));//Kontrollerar att användarnamnet ingår i meddelandet.
        Assert.IsTrue(confirmationMessage.Contains("successfully registered"));//Kontrollerar att strängen ingår i meddelandet.
    }

    [TestMethod] //Testfall för registrering med ogiltigt användarnamn. Förväntar sig ett felmeddelande.
    public void RegisterUser_InvalidUsername_ReturnsFailureMessage()
    {
        //Arrange
        var service = new UserRegistrationService();
        string invalidUsername = "Invalid_U5er";//Ogiltigt användarnamn.

        //Act
        string failureMessage = service.RegisterUser(invalidUsername, "email@mail.com", "Password123!");//Registrerar användaren med ogiltigt användarnamn.

        //Assert
        Assert.IsNotNull(failureMessage);//Kontrollera att felmeddelande returneras
        Assert.IsTrue(failureMessage.Contains("Invalid username format"));//Kontrollera att felmeddelandet innehåller strängen.

    }

    [TestMethod] //Testfall för registrering med ogiltig e-post. Förväntar sig ett felmeddelande.
    public void RegisterUser_InvalidEmail_ReturnsFailureMessage()
    {
        //Arrange
        var service = new UserRegistrationService();
        string invalidEmail = "invalidemail.com";//Ogiltig e-post.

        //Act
        string failureMessage = service.RegisterUser("Validuser", invalidEmail, "Password123!");//Registrerar användaren med ogiltig e-post.

        //Assert
        Assert.IsNotNull(failureMessage); //Kontrollera att felmeddelande returneras
        Assert.IsTrue(failureMessage.Contains("Invalid email format")); //Kontrollera att felmeddelandet innehåller strängen.

    }

    [TestMethod]//Testfall för registrering med ogiltigt lösenord. Förväntar sig ett felmeddelande.
    public void RegisterUser_InvalidPassword_ReturnsFailureMessage()
    {
        //Arrange
        var service = new UserRegistrationService();
        string invalidPassword = "password";//Ogiltigt lösenord.

        //Act
        string failureMessage = service.RegisterUser("Validuser", "email@mail.com", invalidPassword);//Registrerar användaren med ogiltigt lösenord.

        //Assert
        Assert.IsNotNull(failureMessage);//Kontrollera att felmeddelande returneras
        Assert.IsTrue(failureMessage.Contains("Invalid password format")); //Kontrollera att felmeddelandet innehåller strängen.

    }
}
