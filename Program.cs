using System;

namespace OneTimePasswordGenerator
{
    public class OneTimePasswordGenerator
    {
        private const int ValidityPeriodSeconds = 30;
        public string GenerateOTP(string userId, DateTime dateTime)
        {
            string userIdString = userId.ToString();
            string dateTimeString = dateTime.ToString("yyyyMMddHHmmss");

            // Calculate the current time slot based on the validity period
            long timeSlot = dateTime.Ticks / (ValidityPeriodSeconds * TimeSpan.TicksPerSecond);

            // Concatenate user ID, date-time string, and time slot
            string combinedString = userIdString + dateTimeString + timeSlot;

            // Generate a hash code using the combined string
            int hashCode = combinedString.GetHashCode();

            // Convert the hash code to a positive number
            int positiveHashCode = Math.Abs(hashCode);

            // Take the last 6 digits of the positive hash code
            string otp = positiveHashCode.ToString().Substring(positiveHashCode.ToString().Length - 6);

            Console.WriteLine("Validity Period: " + dateTime.AddSeconds(ValidityPeriodSeconds).ToString("yyyy-MM-dd HH:mm:ss"));

            return otp;
        }
    }

    class Program
    {
        public static void Main()
        {
            // Example usage
            string userId = "exampleUser";
            DateTime dateTime = DateTime.Now;

            OneTimePasswordGenerator otpGenerator = new OneTimePasswordGenerator();
            string otp = otpGenerator.GenerateOTP(userId, dateTime);

            Console.WriteLine("Generated OTP: " + otp);
        }
    }
}
