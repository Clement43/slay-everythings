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
        textDegatsPhysiques.text = $"Dégâts Physique: {stats.degatsPhysiques}";
        textDegatsMagiques.text = $"Dégâts Magiques: {stats.degatsMagiques}";
        textDefensePhysique.text = $"Défense Physique: {stats.defensePhysique}";
        textDefenseMagique.text = $"Défense Magique: {stats.defenseMagique}";
        textVitesseAttaque.text = $"Vitesse Attaque: {stats.vitesseAttaque}";
        textVitesseIncantation.text = $"Vitesse Incantation: {stats.vitesseIncantation}";
        textVitesseDeplacement.text = $"Vitesse Déplacement: {stats.vitesseDeplacement}";
        textChanceCrit.text = $"Chance Crit: {(stats.chanceCritique * 100f):F1}%";
        textDegatsCrit.text = $"Dégâts Critique: x{stats.degatsCritique}";
        textNiveau.text = $"Lvl: {stats.niveau}";
        textRegenVie.text = $"Régénération: {stats.regenVieParSeconde}/s";
    }
}