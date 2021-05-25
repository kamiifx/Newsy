using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Model
{
    public class DailyNews:List<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string urlToImage { get; set; }
        public string url { get; set; }

        public string CheckName => $"{Name} {Title}";
    }
}
