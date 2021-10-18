using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Appsettings
{
    public class AppsettingDTO
    {
        public string EMAIL_USER { get; set; }
        public string EMAIL_FROM { get; set; }
        public string EMAIL_PASSWORD { get; set; }
        public string SUPER_ADMIN_EMAIL { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL_SMTP_HOST { get; set; }
        public int SMTP_PORT { get; set; }
        public string STRIPE_PUBLISHABLE_KEY { get; set; }
        public string STRIPE_SECRET_KEY { get; set; }
        public string GOOGLE_SITE_KEY { get; set; }
        public string USER_PASSWORD { get; set; }
        public string GOOGLE_SECRET_KEY { get; set; }
        public string INTRO_VIDEO_LINK { get; set; }
        public string STRIPE_EXPRESSACCOUNT_URL { get; set; }
        public string STRIPE_CLIENT_ID { get; set; }
        public string COMPANY_URL { get; set; }
        public string PAYOUT_PERCENTAGE { get; set; }
        public string JSON_FILECONTAINER { get; set; }
        public string LANDING_INQUIRY { get; set; }
    }
}
