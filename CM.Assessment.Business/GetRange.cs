using System;

namespace CM.Assessment.Business
{

    // Not providing any code/applciation value so removing from project.
    //public class MyArg : EventArgs
    //{
    //    public MyArg(string value)
    //    {
    //        _value = value;
    //    }

    //    string _value = string.Empty;

    //    public string Value
    //    {
    //        get { return _value; }
    //        set
    //        {
    //            _value = value;
    //        }
    //    }
    //}

    public struct RunArgs
    {
        private int _lowRange;
        private int _highRange;
        private string _value1;
        private string _value2;

        /// <summary>
        /// Summary for RunArgs
        /// </summary>
        public RunArgs(int lowRange, int highRange, string value1, string value2)
        {
            _lowRange = lowRange;
            _highRange = highRange;
            _value1 = value1;
            _value2 = value2;
        }

        public int LowRange
        {
            get { return _lowRange; }
        }
        public int HighRange
        {
            get { return _highRange;  }
        }
        public string Value1
        {
            get { return _value1; }
        }
        public string Value2
        {
            get { return _value2; }
        }
    }

    public class GetRange
    {
        public event EventHandler<string> ShowOutput;
        public int LoopedTo { get; private set; }

        public void Run(int lowRange, int highRange, string value1, string value2)
        {
            ExecuteRun(lowRange, highRange, value1, value2);
        }

        public void Run(RunArgs args)
        {
            ExecuteRun(args.LowRange, args.HighRange, args.Value1, args.Value2);
        }

        private void ExecuteRun(int lowRange, int highRange, string value1, string value2)
        {
            LoopedTo = lowRange-1;
            string s = string.Empty;

            for (int i = lowRange; i <= highRange; i++)
            {
                LoopedTo++;
                s = string.Empty;

                if (i > 0)
                {
                    if (i % 3 == 0) s = string.Format("{0} ", value1);
                    if (i % 5 == 0) s += value2;
                }
                if (s == string.Empty)
                    s = i.ToString();

                if (ShowOutput != null)
                    ShowOutput(this, s);
            }
        }
        
    }
}
