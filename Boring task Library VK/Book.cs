using System.Xml.Serialization;

namespace Boring_task_Library_VK
{
    public class Book
    {
        [XmlAttribute]
        public string Title { get; set; }

        // Do not understand this but without it doens't work.
        protected bool Equals(Book other)
        {
            return string.Equals(Title, other.Title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Book) obj);
        }
    }
}