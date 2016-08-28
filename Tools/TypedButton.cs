using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace POC_FilRouge.Tools
{
    class TypedButton : Button
    {
        public enum type
        {
            Mur, Fenetre, Porte
        }


        public type letype { get; set; }
        public TypedButton parent { get; set; }
        public System.Windows.Media.Color color { get; set; }
        public System.Drawing.Bitmap bitmap { get; set; }
        public List<TypedButton> slots { get; set; }


        public TypedButton(type type)
        {
            this.letype = type;
            this.slots = new List<TypedButton>();
        }

        public TypedButton(TypedButton unparent)
        {
            this.parent = unparent;
            this.slots = new List<TypedButton>();
        }

        public TypedButton(TypedButton unparent, type type)
        {
            this.parent = unparent;
            this.letype = type;
            this.slots = new List<TypedButton>();
        }


        #region optionnal
        public enum verticalite
        {
            vertical, horizontal, none
        }
        public verticalite position { get; set; }
        public TypedButton(type type, verticalite unepos)
        {
            this.letype = type;
            this.position = unepos;
        }
        #endregion
    }


}
