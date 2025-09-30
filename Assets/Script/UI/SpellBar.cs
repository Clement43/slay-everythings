using UnityEngine;
using UnityEngine.UI;

public class SpellBar : MonoBehaviour
{

    public PlayerReference playerRef;
    public int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerRef.player.spells.Length > index)
        {
            Sprite spellSprite = playerRef.player.spells[index].getImage();
            Image img = GetComponent<Image>();
            img.sprite = spellSprite;

        }
    }
}
