namespace Iterator
{
    public class LAPaper : INewspaper
    {
        private readonly string[] reporters;
        
        public LAPaper()
        {
            this.reporters = new[] 
            { 
                "Ronald Smith - LA",
                 "Danny Glover - LA",
                 "Yolanda Adams - LA",
                 "Jerry Straight - LA",
                 "Rhonda Lime - LA"
            };
        }

        public IIterator CreateIterator()
        {
            return new LAPaperIterator(reporters);
        }
    }
}
