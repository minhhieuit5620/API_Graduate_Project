using System.Collections.Generic;

namespace ISCommon.Model
{
    public class ListDomainModel
    {
        public List<ListSite> websites { get; set; }
    }
    public class ListSite
    {
        public string name { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public Links _links { get; set; }
    }
    public class Links
    {
        public Self self { get; set; }
    }
    public class Self
    {
        public string href { get; set; }
    }
}
