using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components.Pages.Cms;

[Route("/cms/content/{Id}")]
public partial class DynamicPageContent : ComponentBase
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
}