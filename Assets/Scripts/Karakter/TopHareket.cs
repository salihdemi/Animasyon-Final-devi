using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TopHareket : MonoBehaviour
{
    public float moveForce = 10f;

    private Rigidbody rb;
    [SerializeField] private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() // Fizik hesaplamalarý için
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cam.forward;
        Vector3 right = cam.right;
        Vector3 force = (forward * moveZ + right * moveX) * moveForce;
        rb.AddForce(force);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HeadArea")
        {

        }
    }
}
