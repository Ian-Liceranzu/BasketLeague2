﻿namespace BasketLeague2.Utils.Models;

public class Team
{
    /// <summary>
    /// Team code
    /// </summary>
    public int Codigo { get; set; }

    /// <summary>
    /// Full team name
    /// </summary>
    public string NombreCompleto { get; set; } = "";

    /// <summary>
    /// Short team name
    /// </summary>
    public string Nombre { get; set; } = "";
    /// <summary>
    /// Attack score
    /// </summary>
    public int Ataque { get; set; }
    /// <summary>
    /// Defence score
    /// </summary>
    public int Defensa { get; set; }
    /// <summary>
    /// Shot score
    /// </summary>
    public int Tiro { get; set; }
    /// <summary>
    /// Rebound score
    /// </summary>
    public int Rebote { get; set; }

    /// <summary>
    /// Team owner name
    /// </summary>
    public string Dueño { get; set; } = "";
    /// <summary>
    /// Games played
    /// </summary>
    public int Gp { get; set; }
    /// <summary>
    /// Total point diff
    /// </summary>
    public int Dif { get; set; }
    /// <summary>
    /// Home Wins
    /// </summary>
    public int Wh { get; set; }
    /// <summary>
    /// Visitor Wins
    /// </summary>
    public int Wv { get; set; }
    /// <summary>
    /// Home Looses
    /// </summary>
    public int Lh { get; set; }
    /// <summary>
    /// Visitor Looses
    /// </summary>
    public int Lv { get; set; }

    /// <summary>
    /// The team attacks another
    /// </summary>
    /// <param name="rival">Rival team</param>
    /// <param name="rnd">Random number generator</param>
    /// <returns>Max score the team can achieve</returns>
    public int Atacar(Team rival, Random rnd)
    {
        return 80 + rnd.Next(5, 10) * Ataque + rnd.Next(5, 10) * Tiro - (rnd.Next(1, 5) * rival.Defensa + rnd.Next(1, 5) * rival.Rebote);
    }

    /// <summary>
    /// The team defends from another
    /// </summary>
    /// <param name="rival">Rival team</param>
    /// <param name="rnd">Random number generator</param>
    /// <returns>Lowest score the team can achieve</returns>
    public int Defender(Team rival, Random rnd)
    {
        return 50 + rnd.Next(5, 10) * Defensa + rnd.Next(5, 10) * Rebote - (rnd.Next(1, 5) * rival.Ataque + rnd.Next(1, 5) * rival.Tiro);
    }

    /// <summary>
    /// Knowing the maximun and the minimun calculates the score
    /// </summary>
    /// <param name="rnd">Random number generator</param>
    /// <param name="defender">Minimun score (Defence)</param>
    /// <param name="atacar">Max score (Attack)</param>
    /// <returns>Final team score</returns>
    public static int Resultado(Random rnd, int defender, int atacar)
    {
        return defender < atacar ? rnd.Next(defender, atacar) : rnd.Next(atacar, defender);
    }

    public override string ToString()
    {
        return NombreCompleto;
    }
}