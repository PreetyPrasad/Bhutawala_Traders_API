namespace Bhutawala_Traders_API.Repositories
{
    public class GeneratePassword
    {
        private string MakePassword()
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*";
            const string allChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";

            Random rand = new Random();
            char upper = uppercase[rand.Next(uppercase.Length)];
            char digit = digits[rand.Next(digits.Length)];
            char special = specialChars[rand.Next(specialChars.Length)];

            // Generate 3 more random characters from any set
            string randomChars = new string(new char[]
            {
                allChars[rand.Next(allChars.Length)],
                allChars[rand.Next(allChars.Length)],
                allChars[rand.Next(allChars.Length)]
            });

            // Shuffle and return a 6-character password
            string password = $"{upper}{digit}{special}{randomChars}";
            return new string(password.ToCharArray());
        }
    }
}
