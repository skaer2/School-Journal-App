using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    class Router
    {
        public static Router router = new Router();
        private Frame frame = new Frame();
        private List<Page> pagesHistory = new List<Page>();
        private Window prevModal = new Window();

        public void setMainFrame(Frame mainFrame) {
            frame = mainFrame;
        }

        public void nextPage(Page page) {
            frame.Navigate(page);

            pagesHistory.Add(page);
        }

        public void prevPage() {
            pagesHistory.RemoveAt(pagesHistory.Count - 1);
            frame.Navigate(pagesHistory[pagesHistory.Count - 1]);
        }

        public void showModal(Window modal) {
            prevModal = modal;

            modal.ShowDialog();
        }
    }
}
