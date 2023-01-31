namespace Mkt3.Data;

public class QuestionTopic: ICloneable
{
    
    public int QuestionID { get; set; }
    public int TopicID { get; set; }


    public object Clone()
    {
        var newItem =  (QuestionTopic)MemberwiseClone();
        return newItem;

    }
}