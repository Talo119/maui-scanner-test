using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiApp1.Data;
using ZXing.Net.Maui;
using ZXing;
using ZXing.Net.Maui.Readers;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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
