using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Boring_task_Library_VK
{
    [DebuggerDisplay("{PersonName} {Sex} {Age}")]
    public class Person
    {
        [XmlAttribute]
        public string PersonName { get; set; }
        [XmlAttribute]
        public int Age { get; set; }
        [XmlAttribute]
        public SexEnum Sex { get; set; }
        public List<Book> Books { get; set; }
    }

    public enum SexEnum
    {
        Male,
        Female
    }
}