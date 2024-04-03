namespace ECommerce.Tests;

[TestClass]
public class UserInputValidatorTests
{
    
    [TestMethod]
    public void UsernameValidation_ValidUsername_ReturnsTrue() //Testfall f�r giltigt anv�ndarnamn. F�rv�ntar sig sant som resultat
    {
        //Arrange
        var validator = new UserInputValidator();
        string username = "validUser123"; //Giltigt anv�ndarnamn.

        //Act
        bool isValid = validator.IsValidUsername(username); //Anropa metoden med ett giltigt anv�ndarnamn.

        //Assert
        Assert.IsTrue(isValid); //Kontrollerar om anv�ndarnamnet �r giltigt.
    }

    [TestMethod]
    public void UsernameValidation_InvalidUsername_ReturnsFalse() //Testfall f�r ogiltigt anv�ndarnamn. F�rv�ntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidUsernames = { "shrt", "LongUsernameThatExceedsTheLimit", "invalid_user!" }; //Array med olika sorters ogiltiga anv�ndarnamn.

        foreach (var username in invalidUsernames)//Loop f�r att testa de olika ogiltiga anv�ndarnamnen.
        {
            //Act
            bool isValid = validator.IsValidUsername(username);//Anropar metoden med ogiltiga anv�ndarnamn.

            //Assert
            Assert.IsFalse(isValid, $"Username '{username}' is invalid"); //Kontrollerar att anv�ndarnamnet �r ogiltigt.
        }
    }

    [TestMethod]
    public void PasswordValidation_ValidPassword_ReturnsTrue() //Testfall f�r giltigt l�senord. F�rv�ntar sig sant som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string password = "Password1!";//Giltigt l�senord.

        //Act
        bool isValid = validator.IsValidPassword(password);//Anropa metoden med giltigt l�senord.

        //Assert
        Assert.IsTrue(isValid);//Kontrollerar att l�senordet �r giltigt.
    }

    [TestMethod]
    public void PasswordValidation_InvalidPassword_ReturnsFalse()//Testfall f�r ogiltiga l�senord. F�rv�ntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidPassword = { "shrt", "onlyletters", "53432432" };//Array med olika sorters ogiltiga l�senord.

        foreach (var password in invalidPassword) //Loop f�r att testa de olika ogiltiga l�senorden.
        {
            //Act
            bool isValid = validator.IsValidPassword(password);//Anropar metoden med ogiltigt l�senord.

            //Assert
            Assert.IsFalse(isValid, $"Password '{password}' is invalid");//Kontrollerar att l�senordet �r ogiltigt.
        }
    }

    [TestMethod]
    public void EmailValidation_ValidEmail_ReturnsTrue()//Testfall f�r giltig e-post. F�rv�ntar sig sant som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string email = "user1@mail.com";//giltig epost.

        //Act
        bool isValid = validator.IsValidEmail(email);//Anropar metoden med giltig epost.

        //Assert
        Assert.IsTrue(isValid);//Kontrollerar att eposten �r giltig.
    }

    [TestMethod]
    public void EmailValidation_InvalidEmail_ReturnsFalse() //Testfall f�r ogiltig epost adresser. F�rv�ntar sig falskt som resultat.
    {
        //Arrange
        var validator = new UserInputValidator();
        string[] invalidEmails = { "user@com", "user@example", "userexample.com" };//Array med olika sorters ogiltiga epostadresser.

        foreach(var email in invalidEmails) //Loop f�r att testa de olika ogiltiga eposterna.
        {
            //Act
            bool isValid = validator.IsValidEmail(email);//anropar metoden med ogiltig epost.

            //Assert
            Assert.IsFalse(isValid, $"mailaddress '{email}' is invalid");//Kontrollerar att epost �r ogiltig.
        }
    }
}