using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaNotepad
{
    public class FindNextResult
    {
        private bool searchStatus;
        private int selectionStart;

        public bool SearchStatus 
        {
            get => searchStatus; 
            set => searchStatus = value; 
        }
        public int SelectionStart
        {
            get => selectionStart; 
            set => selectionStart = value;
        }
    }
}
