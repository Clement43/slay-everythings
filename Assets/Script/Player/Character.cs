using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats stats;

    private void Update()
    {
        stats.RegenererVie();
    }

    public void Attaquer(Character cible)
    {
        float degats = stats.degatsPhysiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique !");
        }

        cible.stats.PrendreDegats(degats, false);
    }

    public void LancerSort(Character cible)
    {
        float degats = stats.degatsMagiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique magique !");
        }

        cible.stats.PrendreDegats(degats, true);
    }
}