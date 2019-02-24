using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Exceptions
{
    public class ExceptionManager
    {
    
        public string PATH = @"C:\_temp\logs\";

        private static ExceptionManager instance;

        private static Dictionary<int, ApplicationMessage> messages = new Dictionary<int, ApplicationMessage>();

        private ExceptionManager()
        {
            LoadMessages();
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
                instance = new ExceptionManager();

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();

            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {
            var today = DateTime.Now.ToString("YYYYMMdd");
            var logName = PATH + today  + "_" + "log.txt";

            var message = bex.Message + "\n" + bex.StackTrace + "\n";

            if (bex.InnerException!=null)
                message += bex.InnerException.Message + "\n" + bex.InnerException.StackTrace;

            using (StreamWriter w = File.AppendText(logName))
            {
                Log(bex.Message, w);
            }

            bex.AppMessage = GetMessage(bex);

            throw bex;
    
        }

        public ApplicationMessage GetMessage(BussinessException bex)
        {

            var appMessage = new ApplicationMessage();
            appMessage.Message = "Message not found!";

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {

            var crudMessages = new AppMessagesCrudFactory();

            var lstMessages = crudMessages.RetrieveAll<ApplicationMessage>();

            foreach(var appMessage in lstMessages)
            {
                messages.Add(appMessage.Id, appMessage);
            }  

        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

    }
}
