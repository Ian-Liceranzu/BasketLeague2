namespace BasketLeague2.Utils.Models;

public class TarotCard
{
    public static List<TarotCard> MajorArcana = new()
    {
        new TarotCard
        {
            Number = 0, Name = "The fool", Description = "Todos los stats suman o restan 3 aleatoriamente.",
            Detailed =
                "Escribir libertad en la orilla de una playa es ya tener la libertad de escribirla. Aunque el mar borre esta palabra: la libertad permanece."
        },
        new TarotCard
        {
            Number = 1, Name = "The Magician", Description = "Todos los stats suman 1.",
            Detailed = "Confía en tus habilidades y utiliza tu poder creativo para manifestar tus deseos."
        },
        new TarotCard
        {
            Number = 2, Name = "The Priestess", Description = "Todos los stats suman 2.",
            Detailed = "Escucha tu intuición y conecta con tu sabiduría interna para encontrar respuestas."
        },
        new TarotCard
        {
            Number = 3, Name = "The Empress", Description = "Suma 2 en los stats impares, resta 2 en los pares.",
            Detailed = "Cultiva la abundancia y la fertilidad en todas las áreas de tu vida."
        },
        new TarotCard
        {
            Number = 4, Name = "The Emperor", Description = "Suma 2 en los stats pares, resta 2 en los impares.",
            Detailed = "Establece límites y estructura en tu vida para obtener el éxito y la estabilidad."
        },
        new TarotCard
        {
            Number = 5, Name = "The Hierophant", Description = "Suma 1 en defensa, resta 1 en atletismo.",
            Detailed = "Busca la sabiduría espiritual y encuentra tu propia verdad interna."
        },
        new TarotCard
        {
            Number = 6, Name = "The Lovers", Description = "Suma 2 en dobles, resta 2 en triples",
            Detailed = "Elige con sabiduría y sigue tu corazón en el amor y las decisiones importantes."
        },
        new TarotCard
        {
            Number = 7, Name = "The Chariot", Description = "Suma 3 en triples, resta 3 en dobles.",
            Detailed = "Supera los obstáculos con determinación y confianza en ti mismo."
        },
        new TarotCard
        {
            Number = 8, Name = "Strength", Description = "Suma 5 en triples, resta 1 en todo lo demás.",
            Detailed = "Domina tus impulsos y utiliza el poder del amor y la compasión para superar los desafíos."
        },
        new TarotCard
        {
            Number = 9, Name = "The Hermit", Description = "Suma 5 en defensa, resta 1 en todo lo demás.",
            Detailed = "Busca la soledad y la introspección para encontrar tu luz interna y comprender tu propósito."
        },
        new TarotCard
        {
            Number = 10, Name = "Wheel of Fortune",
            Description = "Todos los stats pares suman 2, los impares restan 3.",
            Detailed =
                "Acepta los cambios inevitables y fluye con ellos, aprovechando las oportunidades que se presentan."
        },
        new TarotCard
        {
            Number = 11, Name = "Justice", Description = "Iguala todos tus stats a tu media.",
            Detailed = "Actúa con equidad y toma decisiones justas basadas en la verdad y la imparcialidad."
        },
        new TarotCard
        {
            Number = 12, Name = "The Hanged Man",
            Description = "Todos los stats bajan 2, el jugador debe ser descartado en el siguiente draft.",
            Detailed = "Suelta el control y permite que las cosas fluyan en su propio tiempo y manera."
        },
        new TarotCard
        {
            Number = 13, Name = "Death",
            Description = "El jugador se retira inmediatamente de la liga, debe remplazarse por uno del draft.",
            Detailed = "Abraza los finales y los cambios inevitables como oportunidades para crecer y renacer."
        },
        new TarotCard
        {
            Number = 14, Name = "Temperance", Description = "Todos los stats impares suman 1.",
            Detailed = "Encuentra el equilibrio y la armonía en todas las áreas de tu vida."
        },
        new TarotCard
        {
            Number = 15, Name = "The Devil",
            Description = "Todos los stats bajan 3, debes mantener a este jugador hasta retirarlo (Hall de la fama).",
            Detailed = "Reconoce y libérate de las cadenas emocionales y mentales que te limitan."
        },
        new TarotCard
        {
            Number = 16, Name = "The Tower", Description = "Suma 4 en rebote, resta 4 en playmaking.",
            Detailed = "Acepta que a veces necesitas que se derrumben viejas estructuras para construir algo mejor."
        },
        new TarotCard
        {
            Number = 17, Name = "The Star",
            Description =
                "Todos los stats suman 3, no puedes descartar a este jugador, tan solo retirarlo (Hall de la fama).",
            Detailed = "Mantén la esperanza y sigue tus sueños, sabiendo que la luz siempre brilla en la oscuridad."
        },
        new TarotCard
        {
            Number = 18, Name = "The Moon", Description = "Todos los stats de todos tus jugadores bajan 2.",
            Detailed =
                "Navega a través de la incertidumbre y las emociones difíciles confiando en tu intuición y sabiduría interna."
        },
        new TarotCard
        {
            Number = 19, Name = "The Sun", Description = "Todos los stats de todos tus jugadores suben 2.",
            Detailed = "Abraza la alegría, la vitalidad y la positividad para disfrutar plenamente de la vida."
        },
        new TarotCard
        {
            Number = 20, Name = "Judgement", Description = "Cambias todos tus jugadores por otros del draft.",
            Detailed = "Trasciende tu pasado y toma decisiones conscientes y basadas en el crecimiento personal."
        },
        new TarotCard
        {
            Number = 21, Name = "The World",
            Description = "Das la vuelta al mundo. Tira otra vez. Más es menos y menos es más.",
            Detailed = "Celebra tus logros, reconocimiento y éxito en todas las áreas de tu vida."
        }
    };

    public int Number { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public string Detailed { get; set; } = "";
}