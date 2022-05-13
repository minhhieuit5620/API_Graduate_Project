using System.Collections.Generic;

namespace KSHYDatabase
{
    public class ISDbValue
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Value { get; set; }
        public Dictionary<string, object> Output { get; set; }
    }
}
