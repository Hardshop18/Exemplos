using System;

namespace WooCommerc
{
    public static class InnerExceptions
    {
        public static string GetExceptionsMsg(this Exception e)
        {
            if (e == null)
                return string.Empty;
            string msg = string.Format("({1}) {2}{0}" +
                                       "\tType:       {3}{0}" +
                                       "\tTargetSite: {4}{0}" +
                                       "\tSource:     {5}{0}" +
                                       "\tTrace:{0}{6}{0}",
                                       Environment.NewLine,
                                       e.HResult,
                                       e.Message,
                                       e.GetType(),
                                       e.TargetSite,
                                       e.Source,
                                       e.StackTrace);
            if (e.InnerException != null)
                msg += Environment.NewLine + e.InnerException.GetExceptionsMsg();
            return msg;
        }
    }
}
