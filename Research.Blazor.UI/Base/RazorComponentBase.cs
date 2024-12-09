using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Research.Blazor.UI.Base
{
    public class RazorComponentBase : ComponentBase
    {
        [CascadingParameter] public MainLayoutCascadingValue LayoutValue { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        public void ShowMessage(string message, MessageType type = MessageType.Success)
        {
            LayoutValue.ShowMessage(message, type);
        }
        public enum MessageType
        {
            Success,
            Error,
            Info,
            Warning
        }
    }
}
