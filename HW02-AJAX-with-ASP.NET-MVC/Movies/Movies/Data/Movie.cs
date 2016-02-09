namespace Movies.Data
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set;  }

        public string LeadingMaleRoleActor { get; set; }

        public string LeadingFemaleRoleActress { get; set; }

        public int ActorAge { get; set; }

        public int ActressAge { get; set; }

        public string Studio { get; set; }

        public string StudioAddress { get; set; }
    }
}