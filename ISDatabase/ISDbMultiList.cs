using System.Collections.Generic;

namespace KSHYDatabase
{
    public class ISDbMultiList<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<List<T>> Value { get; set; }
        public Dictionary<string, object> Output { get; set; }
    }
}
