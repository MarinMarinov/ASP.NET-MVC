namespace Tweeter.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        private ICollection<Tweet> twits;

        public Tag()
        {
            this.twits = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tweet> Twits
        {
            get { return this.twits; }
            set { this.twits = value; }
        }
    }
}
