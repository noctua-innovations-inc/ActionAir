using ActionAir.Data;
using ActionAir.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace ActionAir.Pages;

public sealed partial class Index : ComponentBase, IDisposable
{
    [Inject]
    public required ActionAirClassificationService ClassificationService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required ILogger<Index> Logger { get; set; }

    private Classification[]? Classifications { get; set; }

    protected override void OnInitialized()
    {
        NavigationManager.LocationChanged += LocationChanged;
        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            NavigationManager.NavigateTo("#Open");
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    public void Dispose()
    {
        // Unsubscribe from the event when our component is disposed
        NavigationManager.LocationChanged -= LocationChanged;
    }

    private async Task FetchData(string division)
    {
        Classifications = await ClassificationService.GetClassificationsAsync(division);
        StateHasChanged();
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        var location = new Uri(e.Location);
        var fragment = location.Fragment[1..];
        _ = FetchData(fragment);
    }
}