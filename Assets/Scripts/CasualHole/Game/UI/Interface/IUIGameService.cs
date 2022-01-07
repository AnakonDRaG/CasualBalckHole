using CasualHole.Services;

namespace CasualHole.Game.UI.Interface
{
    public interface IUIGameService: IService
    {
        IWindow WinWindow { get; }
        IWindow LoseWindow { get; }
        IWindow GameMenuWindow { get; }
    }
}