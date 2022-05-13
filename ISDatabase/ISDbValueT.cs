using System.Collections.Generic;

namespace KSHYDatabase
{
    public class ISDbValue<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }
        public Dictionary<string, object> Output { get; set; }
    }
}
