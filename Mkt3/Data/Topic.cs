using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mkt3.Data;

public class Topic: ICloneable
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Owner { get; set; }
    public string Course { get; set; }
    public string Name { get; set; }
    

    public object Clone()
    {
        var newItem =  (Topic)MemberwiseClone();
        return newItem;

    }
}