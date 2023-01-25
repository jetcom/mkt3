namespace Mkt3.Data;

public class Question
{
    public string type { get; set; }
    public string Owner { get; set; }
    public string QuestionID { get; set; }
    public string Prompt { get; set; }
    public int Points { get; set; }
    public string Solution { get; set; }
   
}

public class TrueFalseQuestion : Question
{
    public new bool Solution { get; set; }
}

public class ShortAnswerQuestion : Question
{
    public double LineLength { get; set; }
}