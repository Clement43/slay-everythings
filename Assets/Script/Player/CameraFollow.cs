using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Le joueur à suivre
    private Vector3 offset = new Vector3(0, 10, -10); // Décalage de la caméra
    private Quaternion rotation = Quaternion.Euler(45f, 0, 0f);
    private float followSpeed = 5f;  // Vitesse de suivi

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.rotation = rotation;
        //transform.LookAt(target);
    }
}