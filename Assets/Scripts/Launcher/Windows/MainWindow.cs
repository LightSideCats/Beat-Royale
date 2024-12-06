using LSCore;

namespace StarSavers.Windows
{
    internal class MainWindow : BaseWindow<MainWindow>
    {
        protected override void OnShowing()
        {
            LauncherWindowsData.CurrentShowedWindowIndex = 0;
            LauncherWindowsData.CurrentShowingWindowIndex = 0;
        }
    }
}