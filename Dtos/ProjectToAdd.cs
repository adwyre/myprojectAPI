namespace MyProjectAPI.Dtos
{
    public partial class ProjectToAdd
    {
        public string Title {get; set;}
        public string Tag {get; set;}
        public string Description {get; set;}
        public string Status {get; set;}
        public string Priority {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime DueDate {get; set;}
        public bool Completed {get; set;}

        public ProjectToAdd()
        {
            if (Title == null)
            {
                Title = "";
            }
            if (Tag == null)
            {
                Tag = "";
            }
            if (Description == null)
            {
                Description = "";
            }
            if (Status == null)
            {
                Status = "";
            }
            if (Priority == null)
            {
                Priority = "";
            }
        }
    }
}