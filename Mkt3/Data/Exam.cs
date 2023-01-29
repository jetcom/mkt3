namespace Mkt3.Data;

public class Exam: ICloneable
{
    public string courseName { get; set; }

    public string courseNumber { get; set; }
    public string examName { get; set; }
    public int? maxPoints { get; set; }
    public string? instructor { get; set; }
    public string? term { get; set; }
    public string? note { get; set; }
    public bool useCheckboxes { get; set; }
    public int defaultPoints { get; set; }
    public string defaultSolutionSpace { get; set; }
    public string defaultLineLength { get; set; }
    public string? department { get; set; }
    public string? school { get; set; }
    
    public string examID { get; set; }


    public Exam()
    {
 
    }
    public object Clone()
    {
        var newItem =  (Exam)MemberwiseClone();
      


        return newItem;

    }

}


