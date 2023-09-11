#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace to_do_list;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
#if WINDOWS && DEBUG
    var mauiWindow = handler.VirtualView;
    var nativeWindow = handler.PlatformView;
    nativeWindow.Activate();
    IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
    WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
    AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

	var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

	var new_width  =  displayInfo.Width*0.3;
	var new_height =  displayInfo.Height*0.8; 
    appWindow.Resize(new SizeInt32((int)new_width, (int)new_height));
#endif
		});

		MainPage = new MainPage();
	}
}
