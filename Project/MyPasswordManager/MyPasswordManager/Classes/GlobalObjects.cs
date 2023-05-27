using MyPasswordManager.Controls;
using System.Windows.Controls;

namespace MyPasswordManager.Classes
{
    public class GlobalObjects
    {
        private Frame _ContentFrame;
        private FeedbackWindow _MainFeedbackWindow;
        public GlobalObjects() { }

        public Frame ContentFrame
        {
            get { return _ContentFrame; }
            set { _ContentFrame = value; }
        }

        public FeedbackWindow MainFeedbackWindow
        {
            get { return _MainFeedbackWindow; }
            set { _MainFeedbackWindow = value; }
        }
    }
}
