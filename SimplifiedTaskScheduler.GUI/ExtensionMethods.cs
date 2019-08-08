using System.Drawing;
using System.Windows.Forms;

namespace SimplifiedTaskScheduler.GUI
{
    public static class ExtensionMethods
    {
        public static void SetAppIcon(this Form form)
        {
            form.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
