using UnityEngine;
using UnityEngine.UI;

public class spellBar : MonoBehaviour
{

    public Character character;
    public int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (character.spells.Length > index)
        {
            Sprite spellSprite = character.spells[index].getImage();
            Image img = GetComponent<Image>();
            img.sprite = spellSprite;

        }
    }
}
