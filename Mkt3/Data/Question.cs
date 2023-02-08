using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Mkt3.Data;


public partial class Question: ICloneable
{


    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Owner { get; set; }
    public string QuestionLabel { get; set; }
    public string Prompt { get; set; }
    public int Points { get; set; }
    public List<string> Solutions { get; set; }

    public List<string> WrongAnswers { get; set; }
    
    public List<string> ExamTags { get; set; } 
    
    public bool customLineLength { get; set; }
    public string? LineLength { get; set; }
    public string type { get; set; } 
    public int? GroupID { get; set; }

    [NotMapped]
    public string Group { get; set; }


    
    [NotMapped]
    public string CleanPrompt
    {
        get
        {
            var r= Regex.Replace(Prompt, "<.*?>",string.Empty);
            return r.Replace("&nbsp;", "");

        }
    }


    public Question(string owner)
    {
        Solutions = new List<string>();
        Solutions.Add("");
        WrongAnswers = new List<string>();
        WrongAnswers.Add("");
        ExamTags = new List<string>();
        Owner = owner;
    }
    public object Clone()
    {
        var newItem =  (Question)MemberwiseClone();
        newItem.Solutions = new List<string>();
        foreach (var sol in Solutions)
        {
            newItem.Solutions.Add(sol);
        }

        if (WrongAnswers != null)
        {
            newItem.WrongAnswers = new List<string>();
            foreach (var wrong in WrongAnswers)
            {
                newItem.WrongAnswers.Add(wrong);
            }
        }
        
        if (ExamTags != null)
        {
            newItem.ExamTags = new List<string>();
            foreach (var tag in ExamTags)
            {
                newItem.ExamTags.Add(tag);
            }
        }


        return newItem;

    }


}


