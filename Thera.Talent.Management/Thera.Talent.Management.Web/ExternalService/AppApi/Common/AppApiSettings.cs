namespace Thera.Talent.Management.Web.ExternalService.AppApi.Common
{
    public class AppApiSettings
    {
        public readonly string HostName;

        public AppApiSettings(string hostname)
        {
            HostName = hostname;
        }

        public string UrlLogin
        {
            get
            {
                string path = "api/Users/Login";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlGetUsers
        {
            get
            {
                string path = "api/Users";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlGetUser
        {
            get
            {
                string path = "api/Users/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlCreateUser
        {
            get
            {
                string path = "api/Users";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlUpdateUser
        {
            get
            {
                string path = "api/Users/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlDeleteUser
        {
            get
            {
                string path = "api/Users/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlGetTalents
        {
            get
            {
                string path = "api/Talents";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlGetTalent
        {
            get
            {
                string path = "api/Talents/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlCreateTalent
        {
            get
            {
                string path = "api/Talents";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlUpdateTalent
        {
            get
            {
                string path = "api/Talents/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlDeleteTalent
        {
            get
            {
                string path = "api/Talents/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

    }
}