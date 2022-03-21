namespace ConsequenceServiceApi.Entities;

public class Consequence
{
    public int Id { get; set; }
    public string Body { get; set; }
    public Mood Mood { get; set; }
}
