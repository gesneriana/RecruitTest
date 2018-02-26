using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 自定义的UUID主键
    /// </summary>
    public abstract class UUID
    {
        private static readonly object obj = new object();

        /// <summary>
        /// 产生一个新的UUID
        /// </summary>
        /// <returns></returns>
        public static string getUUID()
        {
            lock (obj)
            {
                return DateTime.Now.ToBinary().ToString("X2") + "-" + Guid.NewGuid().ToString("D");
            }
        }

    }
}
