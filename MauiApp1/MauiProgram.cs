using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiApp1.Data;
using ZXing.Net.Maui;
using ZXing;
using ZXing.Net.Maui.Readers;
#if __ANDROID__
using Android.Webkit;
#endif

namespace MauiApp1;

#if __ANDROID__

public class MyChrome : Android.Webkit.WebChromeClient
{
    public override void OnPermissionRequest(PermissionRequest request)
    {
        request.Grant(request.GetResources());
    }
}
#endif

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureMauiHandlers(handlers =>
			{
				// Gerald: This was added
				BlazorWebViewHandler.BlazorWebViewMapper.AppendToMapping("EnablePermissions", (handler, webview) =>
				{
#if __ANDROID__
				    handler.PlatformView.SetWebChromeClient(new MyChrome());
#endif
				});
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();		
		builder.UseBarcodeReader();

		return builder.Build();
	}
}
