using carsharing.Externals;
using System.Text.Json;

namespace carsharing.Externals
{
    public class EmailSender
    {
        public EmailOptions options;

        public EmailSender()
        {
            string json = File.ReadAllText("Externals/email-sender.json");

            this.options = JsonSerializer.Deserialize<EmailOptions>(json)!;

            System.Diagnostics.Debug.WriteLine($"port: {options.port}");
            System.Diagnostics.Debug.WriteLine($"userName: {options.userName}");

        }
    }
}
