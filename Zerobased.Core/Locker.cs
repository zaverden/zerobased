﻿using System;

namespace Zerobased
{
    public static class Locker
    {
        /// <summary>
        /// Execute standart double check lock thread safe operation.
        /// </summary>
        /// <param name="lockObj">Object to lock.</param>
        /// <param name="checkToExecute">Check if execution need.</param>
        /// <param name="action">Operation to execute.</param>
        public static void DoubleCheck(object lockObj, Func<bool> checkToExecute, Action action)
        {
            if (checkToExecute())
            {
                lock(lockObj)
                {
                    if (checkToExecute())
                    {
                        action();
                    }
                }
            }
        }
    }
}
