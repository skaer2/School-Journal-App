using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace interfaces
{
    interface IWindowFragment
    {
        List<Tuple<Frame, Page>> framesAndBlocks { get; set; }
        void addBlocks();
    }
}
