public class Car
{
   public string Mfgr { get; set; }
   public string Model { get; set; }
   public string Code { get; set; }
   public int Year { get; set; }
}

public class MyOuterType
{
    public List<Car> Vehicles { get; set; }
    public int TestDrive { get; set; }
    public string Path { get; set; }
}

JsonConvert.Deserialize<MyOuterType>(theJson);