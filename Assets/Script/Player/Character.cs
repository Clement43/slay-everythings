using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    public CharacterStats stats;
    private NavMeshAgent agent;

    private void Update()
    {
        stats.RegenererVie();
        agent.speed = stats.vitesseDeplacement;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.vitesseDeplacement;
    }


    public void Attaquer(Character cible)
    {
        float degats = stats.degatsPhysiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique !");
        }

        cible.stats.TakeDamage(degats, false);
    }

    public void LancerSort(Character cible)
    {
        float degats = stats.degatsMagiques;

        if (stats.EstCritique())
        {
            degats = stats.AppliquerCritique(degats);
            Debug.Log("Coup critique magique !");
        }

        cible.stats.TakeDamage(degats, true);
    }
}