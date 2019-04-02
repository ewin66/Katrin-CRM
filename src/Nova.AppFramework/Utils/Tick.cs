using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Katrin.AppFramework.Utils
{
    public static class Tick
    {
#if DEBUG
        static Dictionary<string, int> ticks = new Dictionary<string, int>();
        static Dictionary<string, int> results = new Dictionary<string, int>();
#endif
        public static void In(string label)
        {
#if DEBUG
            lock (ticks)
            {
                ticks[label] = Environment.TickCount;
            }
#endif
        }
        public static void Out(string label)
        {
#if DEBUG
            lock (results)
            {
                results[label] = Environment.TickCount - ticks[label];
            }
#endif
        }
        public static void DumpResults()
        {
#if DEBUG
            lock (results)
            {
                foreach (string label in results.Keys)
                {
                    Debug.WriteLine(String.Format("{0} = {1} ms", label, results[label]), "Tick");
                }
            }
#endif
        }
    }
}
