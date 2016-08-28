using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;

namespace POC_FilRouge.Tools
{
    [TypeConverter(typeof(GridLengthCollectionConverter))]
    public class GridLengthCollection : ReadOnlyCollection<GridLength>
    {
        public GridLengthCollection(IList<GridLength> lengths)
            : base(lengths)
        {
        }
    }
}
