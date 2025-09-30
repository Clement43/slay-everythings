using TMPro;
using UnityEngine;

public class SpellCD : MonoBehaviour
{
    public PlayerReference playerRef;
    public int index;
    private TextMeshProUGUI textMeshCD;
    private Character player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = playerRef.player;
        textMeshCD = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.spells.Length > index) {
            float cdSpell = player.spells[index].getCdSpell();
            textMeshCD.text = cdSpell == 0 ? "" : cdSpell.ToString("F1");
        }

    }
}
