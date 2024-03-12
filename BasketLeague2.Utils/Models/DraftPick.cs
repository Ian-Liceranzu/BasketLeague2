namespace BasketLeague2.Utils.Models;

public class DraftPick
{
    /// <summary>
    /// Pick number
    /// </summary>
    public int Pick { get; set; }
    /// <summary>
    /// Picker team id
    /// </summary>
    public int Team { get; set; }
    /// <summary>
    /// Picked player id
    /// </summary>
    public int Player { get; set; }
}