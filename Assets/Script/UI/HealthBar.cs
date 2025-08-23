using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Character character;
    private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = character.stats.vieMax;
        slider.value = character.stats.vieActuelle;
    }
}
