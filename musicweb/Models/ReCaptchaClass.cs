using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace musicweb.Models
{
    public class ReCaptchaClass
    {
        private string m_Success;
        private List<string> m_ErrorCodes;

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }

        public static string Validate(string encodedResponse)
        {
            WebClient client = new WebClient();
            string privateKey = "6Ldr_H4UAAAAAAThiRzu7VKWGIRLGJPmj_ZfHJ0J";
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                privateKey, encodedResponse));
            ReCaptchaClass captchaResponse = JsonConvert.DeserializeObject<ReCaptchaClass>(reply);
            return captchaResponse.Success.ToLower();
        }
    }
}