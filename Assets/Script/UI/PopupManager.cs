using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel; // Assigne le panel dans l’inspecteur

    public void TogglePopup()
    {
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}