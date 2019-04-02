using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Utils
{
    public class EventArgs<T> : System.EventArgs
    {
        private T _data;

        public EventArgs(T data)
        {
            _data = data;
        }

        public T Data
        {
            get { return _data; }
        }
    }

    public class EventArgs<T1, T2> : System.EventArgs
    {
        private T1 _data1;
        private T2 _data2;

        public EventArgs(T1 data1, T2 data2)
        {
            _data1 = data1;
            _data2 = data2;
        }

        public T1 Data1
        {
            get { return _data1; }
        }

        public T2 Data2
        {
            get { return _data2; }
        }
    }

    public class EventArgs<T1, T2, T3> : System.EventArgs
    {
        private T1 _data1;
        private T2 _data2;
        private T3 _data3;

        public EventArgs(T1 data1, T2 data2, T3 data3)
        {
            _data1 = data1;
            _data2 = data2;
            _data3 = data3;
        }

        public T1 Data1
        {
            get { return _data1; }
        }

        public T2 Data2
        {
            get { return _data2; }
        }

        public T3 Data3
        {
            get { return _data3; }
        }
    }
}
