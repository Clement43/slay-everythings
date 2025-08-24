using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    private int damage;
    private Character owner;
    private LayerMask enemyLayer;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Init(Character owner, int damage, LayerMask enemyLayer)
    {
        this.owner = owner;
        this.damage = damage;
        this.enemyLayer = enemyLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet appartient au layer des ennemis
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            // Récupère le script Character de l'ennemi
            Ennemi enemy = other.GetComponent<Ennemi>();
            if (enemy != null)
            {
                owner.Attaquer(enemy, damage);
            }
            Destroy(gameObject);
        }
    }
}