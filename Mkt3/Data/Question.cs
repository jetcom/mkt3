namespace Mkt3.Data;

public class Question: ICloneable
{
    public string type { get; set; }
    public string Owner { get; set; }
    public string QuestionID { get; set; }
    public string Prompt { get; set; }
    public int Points { get; set; }
    public List<string> Solutions { get; set; }

    public List<string> WrongAnswers { get; set; }
    
    
    public object Clone()
    {
        var newItem =  (Question)MemberwiseClone();
        newItem.Solutions = new List<string>();
        foreach (var sol in this.Solutions)
        {
            newItem.Solutions.Add(sol);
        }

        if (this.WrongAnswers != null)
        {
            newItem.WrongAnswers = new List<string>();
            foreach (var wrong in this.WrongAnswers)
            {
                newItem.WrongAnswers.Add(wrong);
            }
        }


        return newItem;

    }

}


