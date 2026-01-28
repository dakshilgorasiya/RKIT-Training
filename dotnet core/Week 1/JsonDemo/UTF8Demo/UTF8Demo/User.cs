using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTF8Demo
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id : " + Id);
            sb.AppendLine("Name : " + Name);
            sb.AppendLine("Skills : ");
            foreach (var skill in Skills)
            {
                sb.AppendLine(skill.ToString());
            }
            sb.AppendLine("Address:: Street : " + Address?.Street + " City : " + Address?.City + " State : " +Address?.State);

            return sb.ToString();
        }
    }
}
