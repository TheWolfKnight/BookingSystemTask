using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Enumerators {
    public static class EnumeratorTools {

        public static string GetDescription<T>(this T me)
            where T: Enum
            {
            FieldInfo? info = me!.GetType().GetField(me.ToString()!);

            if (info == null) return me.ToString()!;

            DescriptionAttribute[] attr = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attr != null) return attr.First().Description;
            return me.ToString()!;
        }

    }
}
