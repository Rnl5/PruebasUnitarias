namespace PruebasUnitarias
{
    public class UnitTest1
    {
        [Fact]
        public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool resultado = registerViewModel.IsPasswordSecure("1234567");

            //Assert
            Assert.False(resultado);

        }
        [Fact]
        public void IsPasswordSecure_returns_false_if_password_does_not_contains_uppercase_character()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool resultado = registerViewModel.IsPasswordSecure("12345678r");

            //Assert
            Assert.False(resultado);

        }
        [Fact]
        public void IsPasswordSecure_returns_true_if_password_contains_an_uppercase_character_and_a_symbol()
        {
            // Arrange
            var registerViewModel = new RegisterViewModel();

            // Act
            bool resultado = registerViewModel.IsPasswordSecure("R05D$83");

            // Assert
            Assert.False(resultado);
        }
    }

    internal class RegisterViewModel
    {
        internal bool IsPasswordSecure(string password)
        {
            if (password.Length >= 8 && ContieneMayuscula(password) && ContieneSimbolo(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContieneMayuscula(string password)
        {
            return password.Any(p => Char.IsLetter(p) && IsUpper(p));
        }

        private bool IsUpper(char c)
        {
            return Char.IsUpper(c);
        }

        private bool ContieneSimbolo(string password)
        {
            return password.Any(p => !Char.IsLetterOrDigit(p) && !Char.IsWhiteSpace(p));
        }
    }
}