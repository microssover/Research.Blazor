using BlazorBootstrap;
using Blazored.Toast.Services;
using Microsoft.JSInterop;
using static Research.Blazor.UI.Base.RazorComponentBase;

namespace Research.Blazor.UI.Base
{
    public class MainLayoutCascadingValue
    {
        private readonly IToastService _toast;
        private readonly IJSRuntime _js;

        public MainLayoutCascadingValue(IToastService toast, IJSRuntime js)
        {
            _toast = toast;
            _js = js;
        }

        public void ShowMessage(string message, MessageType messageType = MessageType.Success)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    _toast.ShowSuccess(message);
                    break;
                case MessageType.Error:
                    _toast.ShowError(message);
                    break;
                case MessageType.Info:
                    _toast.ShowInfo(message);
                    break;
                case MessageType.Warning:
                    _toast.ShowWarning(message);
                    break;
                default:
                    break;
            }
        }
    }
}
