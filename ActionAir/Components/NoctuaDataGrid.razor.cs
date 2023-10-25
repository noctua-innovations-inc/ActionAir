using ActionAir.Contracts;
using Microsoft.AspNetCore.Components;

namespace ActionAir.Components;

public partial class NoctuaDataGrid<TItem> : ComponentBase
{
    // For parameters, dependency injection, and deferred initialization...
    // ...we use the null-forgiving operator to make the compiler less chatty and happy.

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public IEnumerable<TItem> Data { get; set; } = null!;

    [Inject]
    public IReflection Reflection { get; set; } = null!;

    [Inject]
    protected IHttpContextAccessor ContextAccessor { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        FieldViewDescriptors = Reflection.GetFieldViewDescriptors(typeof(TItem));
    }

    protected bool IsPrerendering => ContextAccessor.HttpContext?.Response?.HasStarted ?? false;

    private IList<IFieldViewDescriptor> FieldViewDescriptors { get; set; } = null!;
}