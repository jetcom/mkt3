using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mkt3.Data;

public class Group
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? ID { get; set; }
    public int TopicID { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public int? MaxQuestions { get; set; }

    public string IDs
    {
        get
        {
            return ID.ToString();
        }
    }

    public object Clone()
    {
        var newItem =  (Topic)MemberwiseClone();
        return newItem;
    }
}
