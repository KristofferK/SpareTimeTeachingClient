namespace SpareTimeTeachingClient.User
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            var successText = Success ? "Success" : "Failed";
            return $"{successText}. {Message}";
        }
    }
}