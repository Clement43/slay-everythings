using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthBarEnnemi : MonoBehaviour
{
    public Image fillImage;
    public Ennemi ennemi; // L'ennemi à suivre
    public Vector3 offset = new Vector3(0, 2, 0); // hauteur au-dessus de l'ennemi
    public RectTransform redBar;
    private float baseWidth = 178;

    private void Start()
    {
        baseWidth = redBar.sizeDelta.x;
    }

    void Update()
    {
        if (ennemi.transform != null)
        {
            transform.position = ennemi.transform.position + offset;
            transform.rotation = Camera.main.transform.rotation; // Toujours face à la caméra
        }
        SetHealth();
    }

    public void SetHealth()
    {

        float pourcentageHeal = ennemi.stats.vieActuelle / ennemi.stats.vieMax ;
        redBar.sizeDelta = new Vector2(baseWidth * pourcentageHeal, redBar.sizeDelta.y);

        fillImage.fillAmount = 10 / 20;
    }
}