using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Katrin.Win
{
    public static class ObjectExtension
    {
        public static dynamic AsDyanmic(this object entity)
        {
            return new SysBits.DynamicProxies.DynamicProxy(entity);
        }
    }
}
