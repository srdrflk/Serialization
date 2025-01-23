using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializationMechanism
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        
        public Person() { } // Parameterless constructor for deserialization

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Special constructor used during deserialization
        protected Person(SerializationInfo info, StreamingContext context)
        {
            // Retrieve data from SerializationInfo and assign it to properties
            Name = info.GetString("Name");
            Age = info.GetInt32("Age");
        }

        // This method is called during serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }
    }
}
