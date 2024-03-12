namespace BasketLeague2.Utils.Models;

public class PlayerTeams
{
    /// <summary>
    /// Player id
    /// </summary>
    public int Player { get; set; }
    /// <summary>
    /// Team id
    /// </summary>
    public int Team { get; set; }
    /// <summary>
    /// Date the player started playing in the team
    /// </summary>
    public DateTime Start { get; set; }
    /// <summary>
    /// Date the player stoped playing in the team
    /// </summary>
    public DateTime End { get; set; }
}