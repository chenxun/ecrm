﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Powerson.Framework
{
    public class TimeTask
    {
        public event System.Timers.ElapsedEventHandler ExecuteTask;

        private static readonly TimeTask _task = null;
        private System.Timers.Timer _timer = null;

        private int _interval = 1;// 默认1秒 [3/14/2009]

        /// <summary>
        /// 时间程序的间隔，单位是秒
        /// </summary>
        public int Interval
        {
            set
            {
                _interval = value;
            }
            get
            {
                return _interval;
            }
        }

        static TimeTask()
        {
            _task = new TimeTask();
        }
        public static TimeTask Instance()
        {
            return _task;
        }
        public void Start()
        {
            if(_timer == null)
            {
                _timer = new System.Timers.Timer(_interval * 1000);
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true;
                _timer.Start();
            }
        }

        protected void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(null != ExecuteTask)
            {
                ExecuteTask(sender, e);
            }
            
        }
        public void Stop()
        {
            if(_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
        }
    }
}
