using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock.Apps.Model
{
    public class CDM
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public Dictionary<string, List<Prop>> Properties { get; set; }
    }

    public class Prop
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
}