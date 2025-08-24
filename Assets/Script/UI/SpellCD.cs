using TMPro;
using UnityEngine;

public class SpellCD : MonoBehaviour
{
    public Character character;
    public int index;
    private TextMeshProUGUI textMeshCD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshCD = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.spells.Length > index) {
            float cdSpell = character.spells[index].getCdSpell();
            textMeshCD.text = cdSpell == 0 ? "" : cdSpell.ToString("F1");
        }

    }
}
