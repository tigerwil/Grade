using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs:EventArgs
    {
        public string existingName { get; set; }
        public string newName { get; set; }

        /*
         * Auto-implemented properties.  
         * Use a hidden field (backing field), C# will automatically create a 
         * field to store the value of this property.
         */

    }
}
