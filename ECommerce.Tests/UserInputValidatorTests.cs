namespace ECommerce.Tests;

[TestClass]
public class UserInputValidatorTests
{
    
    [TestMethod]
    public void UsernameValidation_ValidUsername_ReturnsTrue() //Testfall för giltigt användarnamn. Förväntar sig sant som resultat
    {
        //Arrange
        var validator = new UserInputValidator();
        string username = "validUser123"; //Giltigt användarnamn.

        //Act
        bool isValid = validator.IsValidUsername(username); //Anropa metoden med ett giltigt användarnamn.

        //Assert
        Assert.IsTrue(isValid); //Kontrollerar om användarnamnet är giltigt.
    }

    [TestMethod]
    public void UsernameValidation_InvalidUsername_ReturnsFalse() //Testfall för ogiltigt användarnamn. Förväntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidUsernames = { "shrt", "LongUsernameThatExceedsTheLimit", "invalid_user!" }; //Array med olika sorters ogiltiga användarnamn.

        foreach (var username in invalidUsernames)//Loop för att testa de olika ogiltiga användarnamnen.
        {
            //Act
            bool isValid = validator.IsValidUsername(username);//Anropar metoden med ogiltiga användarnamn.

            //Assert
            Assert.IsFalse(isValid, $"Username '{username}' is invalid"); //Kontrollerar att användarnamnet är ogiltigt.
        }
    }

    [TestMethod]
    public void PasswordValidation_ValidPassword_ReturnsTrue() //Testfall för giltigt lösenord. Förväntar sig sant som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string password = "Password1!";//Giltigt lösenord.

        //Act
        bool isValid = validator.IsValidPassword(password);//Anropa metoden med giltigt lösenord.

        //Assert
        Assert.IsTrue(isValid);//Kontrollerar att lösenordet är giltigt.
    }

    [TestMethod]
    public void PasswordValidation_InvalidPassword_ReturnsFalse()//Testfall för ogiltiga lösenord. Förväntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidPassword = { "shrt", "onlyletters", "53432432" };//Array med olika sorters ogiltiga lösenord.

        foreach (var password in invalidPassword) //Loop för att testa de olika ogiltiga lösenorden.
        {
            //Act
            bool isValid = validator.IsValidPassword(password);//Anropar metoden med ogiltigt lösenord.

            //Assert
            Assert.IsFalse(isValid, $"Password '{password}' is invalid");//Kontrollerar att lösenordet är ogiltigt.
        }
    }

    [TestMethod]
    public void EmailValidation_ValidEmail_ReturnsTrue()//Testfall för giltig e-post. Förväntar sig sant som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string email = "user1@mail.com";//giltig epost.

        //Act
        bool isValid = validator.IsValidEmail(email);//Anropar metoden med giltig epost.

        //Assert
        Assert.IsTrue(isValid);//Kontrollerar att eposten är giltig.
    }

    [TestMethod]
    public void EmailValidation_InvalidEmail_ReturnsFalse() //Testfall för ogiltig epost adresser. Förväntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidEmails = { "user@com", "user@example", "userexample.com" };//Array med olika sorters ogiltiga epostadresser.

        foreach(var email in invalidEmails) //Loop för att testa de olika ogiltiga eposterna.
        {
            //Act
            bool isValid = validator.IsValidEmail(email);//anropar metoden med ogiltig epost.

            //Assert
            Assert.IsFalse(isValid, $"mailaddress '{email}' is invalid");//Kontrollerar att epost är ogiltig.
        }
    }
}