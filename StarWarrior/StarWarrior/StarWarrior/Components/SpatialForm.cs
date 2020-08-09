using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artemis;

namespace StarWarrior.Components
{
    class SpatialForm : Component
    {
        public string SpatialFormFile { get; set; }

        public SpatialForm( string filename)
        {
            SpatialFormFile = filename;
        }
    }
}
