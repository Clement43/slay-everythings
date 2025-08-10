using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public float vieMax = 100f;
    public float vieActuelle = 100f;

    public float degatsPhysiques = 10f;
    public float degatsMagiques = 5f;

    public float defensePhysique = 5f;
    public float defenseMagique = 3f;

    public float vitesseAttaque = 1f;         // Attaques par seconde
    public float vitesseIncantation = 1f;     // Sorts par seconde
    public float vitesseDeplacement = 5f;     // Unités par seconde

    public float chanceCritique = 0.1f;       // 10% = 0.1
    public float degatsCritique = 2f;         // x2 damage

    public int niveau = 1;

    public float regenVieParSeconde = 1f;

    // Méthode pour recevoir des dégâts
    public void TakeDamage(float degats, bool estMagique = false)
    {
        float defense = estMagique ? defenseMagique : defensePhysique;
        float degatsReels = Mathf.Max(0, degats - defense);
        vieActuelle -= degatsReels;

        if (vieActuelle <= 0)
        {
            Mourir();
        }
    }

    public void RegenererVie()
    {
        vieActuelle = Mathf.Min(vieActuelle + regenVieParSeconde * Time.deltaTime, vieMax);
    }

    private void Mourir()
    {
        Debug.Log("Le personnage est mort.");
        // Tu peux appeler un event ou notifier un GameManager ici
    }

    public bool EstCritique()
    {
        return Random.value < chanceCritique;
    }

    public float AppliquerCritique(float degatsDeBase)
    {
        return EstCritique() ? degatsDeBase * degatsCritique : degatsDeBase;
    }
}