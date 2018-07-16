using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupGuardian
{
    public class TelegramException : Exception
    {
        public int code;
        public TelegramException() : base() { }
        public TelegramException(int err, string errText)
        : base(errText)
        {
            code = err;
        }
    }
    public class WebhookEnabledException : TelegramException
    {
        public WebhookEnabledException() : base(409, "Webhook has already been enabled for this bot.") { }
    }
    
}
