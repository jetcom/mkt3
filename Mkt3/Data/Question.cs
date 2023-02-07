using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mkt3.Data;

public class Question: ICloneable
{
    public string type { get; set; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string QuestionLabel { get; set; }
    public string Prompt { get; set; }
    public int Points { get; set; }
    public List<string> Solutions { get; set; }

    public List<string> WrongAnswers { get; set; }
    
    public List<string> ExamTags { get; set; } 
    
    public bool customLineLength { get; set; }
    public string? LineLength { get; set; }
    
    public int? GroupID { get; set; }

    [NotMapped]
    public string Group { get; set; }



    public Question()
    {
        Solutions = new List<string>();
        Solutions.Add("");
        WrongAnswers = new List<string>();
        WrongAnswers.Add("");
        ExamTags = new List<string>();
    }
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
        
        if (this.ExamTags != null)
        {
            newItem.ExamTags = new List<string>();
            foreach (var tag in this.ExamTags)
            {
                newItem.ExamTags.Add(tag);
            }
        }


        return newItem;

    }

}


