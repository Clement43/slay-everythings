using UnityEngine;
using UnityEngine.AI;

public class Ennemi : MonoBehaviour
{
    public CharacterStats stats;
    private NavMeshAgent agent;

    private Transform player;
    public float chaseRange = 10f;

    private float lastAttackTime;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = stats.vitesseDeplacement;

        // Recherche automatique du joueur par son tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'Player' trouvé dans la scène !");
        }
    }

    private void Update()
    {
        if (player == null) return; // Si pas de joueur trouvé, on arrête

        stats.RegenererVie();
        agent.speed = stats.vitesseDeplacement;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= chaseRange)
        {
            agent.SetDestination(player.position);

            if (distance <= 3)
            {
                agent.isStopped = true;
                Attack();
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }

    void Attack()
    {
        if (Time.time - lastAttackTime > (1f / stats.vitesseAttaque))
        {
            lastAttackTime = Time.time;

            Character character = player.GetComponent<Character>();
            if (character != null)
            {
                character.stats.PrendreDegats(10, false);
            }
        }
    }
}