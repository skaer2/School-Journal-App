using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaces
{
    // usage: add an object of this class to a page(window) class, 
    //        then with the "addFrameBlock" function add each frame and a block for it.
    //        Use "loadBlocks" to load all added blocks in the page
    public static class WindowFragment 
    {
        public static void loadBlocks(this Page page, List<Tuple<Frame, Page>> framesAndBlocks)
        {
            foreach (var frAndBl in framesAndBlocks)
            {
                loadBlock(frAndBl.Item1, frAndBl.Item2);
            }
        }

        private static void loadBlock(Frame frame, Page block)
        {
            frame.Navigate(block);
        }

        }
}
