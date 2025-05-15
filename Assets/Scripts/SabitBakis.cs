using UnityEngine;

public class SabitBakis : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Fareyi ortada kilitle
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);

        transform.position = playerBody.position;
    }
}
