using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    // référence assignée dans l’inspecteur
    public InputActionReference clickAction; 
    public InputActionReference stopAction; 
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void OnEnable()
    {
        clickAction.action.performed += OnClick;
        stopAction.action.performed += Stop;
        clickAction.action.Enable();
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
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            // Si le personnage se déplace, on lui fait face à la direction du mouvement
            Quaternion targetRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
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