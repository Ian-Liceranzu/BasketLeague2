namespace BasketLeague2.Utils.Models;

public class Badge
{
    /// <summary>
    /// Team/Player id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Badge name
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Badge description
    /// </summary>
    public string Description { get; set; } = "";
    /// <summary>
    /// Badge color
    /// </summary>
    public string Color { get; set; } = "";
}