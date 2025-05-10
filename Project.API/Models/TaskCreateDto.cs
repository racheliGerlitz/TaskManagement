using Project.Enum;

public class TaskCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ReporterName { get; set; }
    public string ReporterEmail { get; set; }
    public Role ReporterRole { get; set; }
    public string AssigneeName { get; set; }
    public string AssigneeEmail { get; set; }
    public Role AssigneeRole { get; set; }
    public Priority Priority { get; set; }
    public float EstimationTime { get; set; }
}
