using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using POC_FilRouge.Tools;

namespace POC_FilRouge.Tools
{
    public class SimpleGrid : Grid
    {
        private GridLengthCollection _rows;
        public GridLengthCollection Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                RowDefinitions.Clear();
                if (_rows == null)
                    return;
                foreach (var length in _rows)
                {
                    RowDefinitions.Add(new RowDefinition { Height = length });
                }
            }
        }

        private GridLengthCollection _columns;
        public GridLengthCollection Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;
                if (_columns == null)
                    return;
                ColumnDefinitions.Clear();
                foreach (var length in _columns)
                {
                    ColumnDefinitions.Add(new ColumnDefinition { Width = length });
                }
            }
        }
    }
}
