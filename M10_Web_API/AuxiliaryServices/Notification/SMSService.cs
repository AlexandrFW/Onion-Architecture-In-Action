using Domain.Interfaces.Services;
using Domain.ServiceTools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Tools;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Services.Notification
{
    public class SMSService : ISMSService
    {
        private ILogger<SMSService> _logger;
        private SMSConf _smsConf;

        public SMSService(IConfigurationSection confSection, ILogger<SMSService> logger)
        {
            _logger = logger;
            _smsConf = JSONSerializer.JSONGetSection<SMSConf>(confSection);
        }

        public void SendSMS(string sMsg, string phoneTo)
        {
            string accountSid = _smsConf.AccountSid;
            string authToken = _smsConf.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: sMsg,
                from: new Twilio.Types.PhoneNumber(_smsConf.PhoneFrom),
                to: new Twilio.Types.PhoneNumber(phoneTo)
                );
        }
    }
}