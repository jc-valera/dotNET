using DependencyInjectionWFA.Services;

namespace DependencyInjectionWFA.BLL
{
    public class MessageServiceBLL : IMessageServiceBLL
    {
        public string GetSuccessMessage()
        {
            var message = "Message Success!!";

            return message;
        }
    }
}
