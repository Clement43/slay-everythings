using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public InputActionReference clickAction;
    public InputActionReference stopAction;
    private NavMeshAgent agent;
    private Animator animator; // référence vers l’Animator

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        animator = GetComponent<Animator>(); // récupère l’Animator sur le même GameObject
    }

    void OnEnable()
    {
        clickAction.action.performed += OnClick;
        stopAction.action.performed += Stop;
        clickAction.action.Enable();
        stopAction.action.Enable();
    }

    void OnDisable()
    {
        clickAction.action.performed -= OnClick;
        stopAction.action.performed -= Stop;
        clickAction.action.Disable();
        stopAction.action.Disable();
    }

    void Update()
    {
        // Gestion de la rotation
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Mise à jour de l’animation en fonction de la vitesse
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void Stop(InputAction.CallbackContext context)
    {
        agent.ResetPath();
    }
}