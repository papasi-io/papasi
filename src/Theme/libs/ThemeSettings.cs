namespace Papasi.Theme.libs;

class ThemeSettings
{
	public static ThemeBase config;

	public static void init(IConfiguration configuration)
	{
		config = configuration.GetSection("Theme").Get<ThemeBase>();
	}
}
