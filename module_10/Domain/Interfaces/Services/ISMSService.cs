namespace Domain.Interfaces.Services
{
    public interface ISMSService
    {
        public void SendSMS(string sMsg, string phoneTo);
    }
}