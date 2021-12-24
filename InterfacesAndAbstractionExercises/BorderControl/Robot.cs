using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BorderControl
{
    public class Robot : IIdentify
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get ; set; }
        public string Id { get; set; }
    }
}
