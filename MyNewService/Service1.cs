using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MyNewService
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer(); // name space(using System.Timers;)  
        public Service1()
        {
            InitializeComponent();
        }

        protected override  void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 50000; //number in milisecinds  
            timer.Enabled = true;

            bool istrue = true;
            while (istrue) { 
                Thread thr = new Thread(new ThreadStart(job1));            
                thr.Start();
                Thread.Sleep(10000);
                Thread thrq = new Thread(new ThreadStart(job2)); 
                thrq.Start();
                Thread.Sleep(10000);
                Thread thrq1 = new Thread(new ThreadStart(job2));
                thrq1.Start();
                Thread.Sleep(10000);
                Thread thrq2 = new Thread(new ThreadStart(job2));
                thrq2.Start();
                Thread.Sleep(10000);
                Thread thrq3 = new Thread(new ThreadStart(job2));           
                thrq3.Start();                        
                Thread.Sleep(10000);
                Thread thr1 = new Thread(new ThreadStart(job1));
                thr1.Start(); 
                Thread.Sleep(10000);
                Thread thr2 = new Thread(new ThreadStart(job1));                     
                thr2.Start();
                Thread.Sleep(50000);
            }
           
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
             
        }
        public void WriteToFile(string Message)
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
          
        }
        public void job1()
        {
            int a = 0;
            while (true)
            {
                for (int i = 0; i < 1000; i++)
                    a = a + 58 + i/44*i*33;
            }
        }
        public void job2()
        {
            int a = 0;
            while (true)
            {
                for(int i=0;i<1000;i++)
                    a = a + 58+i/44*i;
            }
        }
    }
}
