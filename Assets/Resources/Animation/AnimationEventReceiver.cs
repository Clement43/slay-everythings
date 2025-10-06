using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    // Cette fonction sera appelée par ton Animation Event
    public void ResetBool()
    {
        animator.SetBool("punch", false);
        Debug.Log("Event d'animation déclenché → MonBool = false");
    }
}
