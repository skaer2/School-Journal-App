using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using School_Journal_App_VSProject.pages;

namespace School_Journal_App_VSProject.models
{
    class WindowRouter
    {
        public static WindowRouter router = new WindowRouter();
        private Frame mainFrame = new Frame();

        public void setFrame(Frame frame) 
        {
            mainFrame = frame;
        }

        public void openPage(Page page) 
        {
            mainFrame.Navigate(page);
        }
    }
}
