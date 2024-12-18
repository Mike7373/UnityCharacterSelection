using TMPro;
using UnityEngine;

//Essendo un singleton aggiungo "sealed" per evitare che questa classe possa essere estesa ad altre classi
public sealed class StatsCanvas : MonoBehaviour
{
    public TMP_Text CharacterName;
    public TMP_Text StrengthStat;
    public TMP_Text HealthStat;
    public TMP_Text SpeedStat;
    public TMP_Text MagicPowerStat;

    

    public static StatsCanvas Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("StatsCanvas è un Singleton, non è possibile avere più di un'istanza!");
        }
        Instance = this;
    }

    private void Start()
    {
        ToggleCanvas(false);
    }

    /// <summary>
    /// Setta i valori delle statistiche del player all'interno della UI
    /// </summary>
    /// <param name="stats"></param>
    public static void DrawStats(Stats stats, string name)
    {
        Instance.CharacterName.text = name;
        Instance.StrengthStat.text = stats.strength.ToString();
        Instance.HealthStat.text = stats.health.ToString();
        Instance.SpeedStat.text = stats.speed.ToString();
        Instance.MagicPowerStat.text = stats.magicPower.ToString();
    }

    /// <summary>
    /// Imposta lo stato di visibilità del canvas
    /// </summary>
    /// <param name="toggle"></param>
    public static void ToggleCanvas(bool toggle)
    {
        Instance.gameObject.SetActive(toggle);
    }
}
