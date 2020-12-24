using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    // usage: add an object of this class to a page(window) class, 
    //        then with the "addFrameBlock" function add each frame and a block for it.
    //        Use "loadBlocks" to load all added blocks in the page
    class WindowFragment 
    {

        private List<Tuple<Frame, Page>> framesAndBlocks;

        public WindowFragment()
        {
            framesAndBlocks = new List<Tuple<Frame, Page>>();
        }
        public void addFrameBlock(Frame frame, Page block)
        {
            framesAndBlocks.Add(Tuple.Create<Frame, Page>(frame, block));
        }

        public void loadBlocks()
        {
            foreach (var frAndBl in framesAndBlocks)
            {
                loadBlock(frAndBl.Item1, frAndBl.Item2);
            }
        }

        private void loadBlock(Frame frame, Page block)
        {
            frame.Navigate(block);
        }

        }
}
