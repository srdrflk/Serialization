﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinarySerialization
{
    [Serializable]
    public class Employee
    {
        [XmlElement("EmployeeName")]
        public string EmployeeName { get; set; }

        public Employee() { } // Parameterless constructor for serialization
        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }
    }
}
