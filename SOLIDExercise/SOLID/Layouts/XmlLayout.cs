using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<log>");
                sb.AppendLine("   <date>{0}</date>");
                sb.AppendLine("   <level>{1}</level>");
                sb.AppendLine("   <message>{2}</message>");
                sb.Append("</log>");
                return sb.ToString();

             //  @"
             //  <log>
             //      < date >{0}</ date >
             //      < level >{1}</ level >
             //      < message >{2}</ message >
             //  </ log >";
             // format can also be writtern this way

            }
        }
           
    }
}
