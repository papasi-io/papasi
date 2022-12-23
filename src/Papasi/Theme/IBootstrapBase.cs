using Papasi.Theme.libs;

namespace Papasi.Theme;

public interface IBootstrapBase
{
    void initThemeMode();
    
    void initThemeDirection();
    
    void initRtl();

    void initLayout();

    void init(ITheme theme);
}