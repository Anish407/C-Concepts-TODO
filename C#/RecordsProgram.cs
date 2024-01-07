// See https://aka.ms/new-console-template for more information
Information information = new Information("Anish",10);
Information information2 = new Information("Anish",10);

Information information3 = information with { name="Jiya" }; 

InformationWithProperties informationWithProperties = new InformationWithProperties("Anish", 35)
{
    pin=101
};

InformationWithProperties informationWithProperties2 = informationWithProperties with { pin = 122 };
informationWithProperties.pin = 500;

Console.WriteLine(informationWithProperties2); // The value has not changed to 500


InformationWithProperties deconstructedValue = informationWithProperties;





#region Copy
InformationWithPropertiesCopy informationWithPropertiesCopy = new InformationWithPropertiesCopy
{
    pin = 500,
    age = 2,
    code = 12
};

InformationWithPropertiesCopy informationWithPropertiesCopy1 = informationWithPropertiesCopy;

InformationWithPropertiesCopy informationWithPropertiesCopy2 = informationWithPropertiesCopy with { pin = 900 };

informationWithPropertiesCopy.pin = 400;
informationWithPropertiesCopy.age = 400;


Console.WriteLine($"Original: {informationWithPropertiesCopy}"); //Original: InformationWithPropertiesCopy { pin = 400, age = 400, code = 12 }
Console.WriteLine($"Copy reference: {informationWithPropertiesCopy1}"); //Copy reference: InformationWithPropertiesCopy { pin = 400, age = 400, code = 12 }
Console.WriteLine($"Copy  with: {informationWithPropertiesCopy2}"); //Copy  with: InformationWithPropertiesCopy { pin = 900, age = 2, code = 12 }

#endregion

#region Equality
DataWithList data1 = new DataWithList("Anish", 10, new List<Information> { information, information2 });
DataWithList data2 = new DataWithList("Anish", 10, new List<Information> { information, information2 });

DataWithoutList dataWihoutList1 = new DataWithoutList("Anish", 10, information);
DataWithoutList dataWihoutList2 = new DataWithoutList("Anish", 10, information);

Console.WriteLine(information == information2); // returns true
Console.WriteLine(data1 == data2); // returns false Since it has a list
Console.WriteLine(dataWihoutList1 == dataWihoutList2); // returns false Since it has a list 
#endregion


#region Display

//Record types have a compiler-generated ToString method that displays the names and values of public properties and fields.The ToString method returns a string of the following format:
//< record type name> { <property name> = <value>, <property name> = <value>, ...}
//The string printed for <value> is the string returned by the ToString() for the type of the property.



Console.WriteLine(information); // Information { name = Anish, age = 10 }
Console.WriteLine($"Data with List: {data1}"); // Data with List: DataWithList { name = Anish, age = 10, information = System.Collections.Generic.List`1[Information] }
Console.WriteLine($"Data without List: {dataWihoutList1}"); //Data without List: DataWithoutList { name = Anish, age = 10, information = Information { name = Anish, age = 10 } }

#endregion

Console.ReadLine();

public record Information(string name, int age); // they are immutable, setters are init 
public record DataWithList(string name, int age, List<Information> information);
public record DataWithoutList(string name, int age, Information information);

public record InformationWithProperties(string name, int age)
{
    public int pin { get; set; }
}

public record InformationWithPropertiesCopy
{
    public int pin { get; set; }
    public int age { get; set; }
    public int code { get; set; }
}


// A record can inherit from another record. However, a record can't inherit from a class, and a class can't inherit from a record


