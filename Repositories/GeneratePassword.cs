namespace Bhutawala_Traders_API.Repositories
{
    public class AutoGenratePasswd
    {
        public string Autopasswd()
        {
            var length = 6; // You can adjust the length as per your requirement
            var random = new Random();
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$%^&*()_+";
            var password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[random.Next(validChars.Length)];
            }
            return new string(password);
        }
    }
}
