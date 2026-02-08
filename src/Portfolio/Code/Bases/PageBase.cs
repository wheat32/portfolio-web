using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace Portfolio.Code.Bases;

public class PageBase : ComponentBase, IDisposable
{
    private string? _lastUri;

    [Inject] protected NavigationManager? NavigationManager { get; set; }

    [Inject] protected IJSRuntime? JSRuntime { get; set; }

    public void Dispose()
    {
        NavigationManager!.LocationChanged -= OnLocationChanged;
    }

    protected override void OnInitialized()
    {
        _lastUri = NavigationManager?.Uri;
        NavigationManager!.LocationChanged += OnLocationChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) await JSRuntime!.InvokeVoidAsync("loadBlazor");
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        // Avoid duplicate calls
        if (e.Location != _lastUri)
        {
            _lastUri = e.Location;
            await JSRuntime!.InvokeVoidAsync("dispatchBlazorNavigation", e.Location);
        }
    }
}