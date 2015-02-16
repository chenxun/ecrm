using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Powerson.Framework;
using Powerson.BusinessFacade;

namespace Powerson.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            TimeTask.Instance().ExecuteTask += new System.Timers.ElapsedEventHandler(Global_ExecuteTask_OpenSea);
            TimeTask.Instance().Interval = 60 * 60 * 4;
            TimeTask.Instance().Start();
        }

        private void Global_ExecuteTask_OpenSea(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Properties.Settings.Default.TIMETASK_OPENSEA)
            {
                //CustomerService cs = new CustomerService();
                //cs.ServiceDataCommon = new Powerson.DataAccess.SqlDataCommon(Powerson.Web.Properties.Settings.Default.CONNECTSTRING);
                //cs.ThrowIntoOpenSea();
                //cs.MakeOpenSeaCustomerCanBeApply();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            TimeTask.Instance().Stop();
        }
    }
}