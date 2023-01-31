namespace Mkt3.Data;

public class Topic: ICloneable
{
    
    public int ID { get; set; }
    public string Course { get; set; }
    public string Name { get; set; }
    

    public object Clone()
    {
        var newItem =  (Topic)MemberwiseClone();
        return newItem;

    }
}