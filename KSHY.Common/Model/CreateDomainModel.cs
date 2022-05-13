using System.Collections.Generic;

namespace ISCommon.Model
{
    public class CreateDomainModel
    {
        public string name { get; set; }
        public string id { get; set; }
        public string physical_path { get; set; }
        public int key { get; set; }
        public string status { get; set; }
        public bool server_auto_start { get; set; }
        public string enabled_protocols { get; set; }
        public Limits limits { get; set; }
        public List<Bindings> bindings { get; set; }
        public Application_pool application_pool { get; set; }
        public LinkList _links { get; set; }
    }
    public class Limits
    {
        public double connection_timeout { get; set; }
        public long max_bandwidth { get; set; }
        public long max_connections { get; set; }
        public int max_url_segments { get; set; }
    }
    public class Bindings
    {
        public string protocol { get; set; }
        public string binding_information { get; set; }
        public string ip_address { get; set; }
        public int port { get; set; }
        public string hostname { get; set; }
    }
    public class Application_pool
    {
        public string name { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public Links _links { get; set; }
    }
    public class LinkList
    {
        public Self authentication { get; set; }
        public Self authorization { get; set; }
        public Self default_document { get; set; }
        public Self delegation { get; set; }
        public Self directory_browsing { get; set; }
        public Self files { get; set; }
        public Self handlers { get; set; }
        public Self http_redirect { get; set; }
        public Self ip_restrictions { get; set; }
        public Self logging { get; set; }
        public Self modules { get; set; }
        public Self monitoring { get; set; }
        public Self request_filtering { get; set; }
        public Self request_tracing { get; set; }
        public Self requests { get; set; }
        public Self response_compression { get; set; }
        public Self response_headers { get; set; }
        public Self self { get; set; }
        public Self ssl { get; set; }
        public Self static_content { get; set; }
        public Self url_rewrite { get; set; }
        public Self vdirs { get; set; }
        public Self webapps { get; set; }
    }
   
}
