using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public Character targetCharacter;

    //public TextMeshProUGUI textVie;
    public TextMeshProUGUI textDegatsPhysiques;
    public TextMeshProUGUI textDegatsMagiques;
    public TextMeshProUGUI textDefensePhysique;
    public TextMeshProUGUI textDefenseMagique;
    public TextMeshProUGUI textVitesseAttaque;
    public TextMeshProUGUI textVitesseIncantation;
    public TextMeshProUGUI textVitesseDeplacement;
    public TextMeshProUGUI textChanceCrit;
    public TextMeshProUGUI textDegatsCrit;
    public TextMeshProUGUI textNiveau;
    public TextMeshProUGUI textRegenVie;



    private void Update()
    {
        if (targetCharacter == null) return;
        CharacterStats stats = targetCharacter.stats;
        textDegatsPhysiques.text = $"D�g�ts Physique: {stats.degatsPhysiques}";
        textDegatsMagiques.text = $"D�g�ts Magiques: {stats.degatsMagiques}";
        textDefensePhysique.text = $"D�fense Physique: {stats.defensePhysique}";
        textDefenseMagique.text = $"D�fense Magique: {stats.defenseMagique}";
        textVitesseAttaque.text = $"Vitesse Attaque: {stats.vitesseAttaque}";
        textVitesseIncantation.text = $"Vitesse Incantation: {stats.vitesseIncantation}";
        textVitesseDeplacement.text = $"Vitesse D�placement: {stats.vitesseDeplacement}";
        textChanceCrit.text = $"Chance Crit: {(stats.chanceCritique * 100f):F1}%";
        textDegatsCrit.text = $"D�g�ts Critique: x{stats.degatsCritique}";
        textNiveau.text = $"Lvl: {stats.niveau}";
        textRegenVie.text = $"R�g�n�ration: {stats.regenVieParSeconde}/s";
    }
}