using Domain.Enums;
using Flunt.Notifications;


namespace Application.Results
{
    public class Result
    {
        public object Data { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public ErrorCode? Error { get; set; }
        public Result()
        {
        }

        public void AddNotification(string error, ErrorCode errorCode)
        {
            var notification = new Notification(errorCode.ToString(), error);
            Notifications.Add(notification);
            Error = errorCode;
        }        
    }
}
