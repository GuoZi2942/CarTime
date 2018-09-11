using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarTime
{
    public class CarTime
    {
        /// <summary>
        /// 主键
        /// </summary>
        private string mypk;

        public string Mypk
        {
            get { return mypk; }
            set { mypk = value; }
        }

        /// <summary>
        /// 开始位置
        /// </summary>
        private string lbstart;

        public string Lbstart
        {
            get { return lbstart; }
            set { lbstart = value; }
        }

        /// <summary>
        /// 结束位置
        /// </summary>
        private string lbend;

        public string Lbend
        {
            get { return lbend; }
            set { lbend = value; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        private string dtstart;

        public string Dtstart
        {
            get { return dtstart; }
            set { dtstart = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        private string dtend;

        public string Dtend
        {
            get { return dtend; }
            set { dtend = value; }
        }
        /// <summary>
        /// 里程
        /// </summary>
        private string licheng;

        public string Licheng
        {
            get { return licheng; }
            set { licheng = value; }
        }

        /// <summary>
        /// 花费的时间
        /// </summary>
        private string costtime;

        public string Costtime
        {
            get { return costtime; }
            set { costtime = value; }
        }
        /// <summary>
        /// 花费的金额
        /// </summary>
        private string jine;

        public string Jine
        {
            get { return jine; }
            set { jine = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string demo;

        public string Demo
        {
            get { return demo; }
            set { demo = value; }
        }

        public CarTime()
        {
        }
    }
}
