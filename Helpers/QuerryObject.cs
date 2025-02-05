namespace Api.Helpers;

public class QuerryObject
{
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;

    public string? SortBy { get; set; } = null;

    public bool IsDescending { get; set; } = false;
}