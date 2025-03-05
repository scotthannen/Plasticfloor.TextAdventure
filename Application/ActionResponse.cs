namespace Application
{
    public class ActionResponse
    {
        public ActionResponse(bool success) => Success = success;

        public ActionResponse(bool success, string failureReason)
        {
            Success = success;
            FailureReason = failureReason;
        }

        public bool Success { get; }

        public string FailureReason { get; }

        public static ActionResponse Ok() => new ActionResponse(true);

        public static ActionResponse Fail() => new ActionResponse(false);

        public static ActionResponse Fail(string failureReason) => new ActionResponse(false, failureReason);
    }
}
