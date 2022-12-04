namespace CloudChatService.Core.DTOs
{
    public class APIResponse
    {
        public bool Success => Errors == null;
        public string Message { get; set; }
        public List<int> Errors { get; private set; }

        public APIResponse(string message, int erorrNumber)
        {
            if(erorrNumber == 0)
            {
                Message = $"Request done successfully -> {message}";
            }
            else
            {
                AddError(erorrNumber);
                Message = $" Request failed -> {message}";
            }
        }

        public void AddError(int error)
        {
            if (Errors == null)
                Errors = new List<int>();

            Errors.Add(error);
        }
        public void AddErrors(List<int> errors)
        {
            if (Errors == null)
                Errors = new List<int>();

            Errors.AddRange(errors);
        }

    }
    public class APIResponse<T> : APIResponse
    {
        public APIResponse(string message, int erorrNumber) : base(message, erorrNumber)
        {
        }
        public T Data { get; set; }

    }
}
