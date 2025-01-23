using BinarySerializationMechanism;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("Serdar", 41);

        string filePath = "person.dat";

        // Serialize
        IFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, person);
        }
        Console.WriteLine("Object Serialized.");

        // Deserialize
        Person deserializedPerson;
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            deserializedPerson = (Person)formatter.Deserialize(stream);
        }
        Console.WriteLine("Object Deserialized.");
        Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
    }
}