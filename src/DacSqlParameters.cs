﻿using System;
using System.Collections.Generic;

namespace am.kon.packages.dac.primitives
{
    /// <summary>
    /// A class used to pass parameters to DAC for SQL commands execution
    /// </summary>
    public class DacSqlParameters : List<KeyValuePair<string, object>>
    {
        /// <summary>
        /// Add SQL command parameter item
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        public void AddItem(string name, object value)
        {
            this.Add(new KeyValuePair<string, object>(name, value));
        }
    }
}

