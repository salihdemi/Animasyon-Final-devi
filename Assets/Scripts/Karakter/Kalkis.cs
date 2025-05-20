using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kalkis : MonoBehaviour
{
    public static bool fps;

    [SerializeField] GameObject body;
    [SerializeField] private GameObject fakeBody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("baglanti"))
        {
            Getup();
        }
    }
    void Getup()
    {
        body.SetActive(false);
        GetComponent<Rigidbody>().useGravity = false;
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        Vector3 target = new Vector3(transform.position.x, 3.5f, transform.position.y);

        while (transform.position.y + 0.1f <= 3.5f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.01f);
            yield return null;
        }
        EnterFpsState();
    }

    void EnterBallState()
    {
        GetComponent<Fps>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        ExitFpsState();
    }
    void EnterFpsState()
    {
        fps= true;
        GetComponent<Fps>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        SetCameraParent(transform);
        ExitBallState();
    }
    void ExitBallState()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<TopHareket>().enabled = false;
    }
    void ExitFpsState()
    {
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        SetCameraParent(null);
    }

    void SetCameraParent(Transform parent)
    {
        Transform cam = Camera.main.transform;
        Quaternion rotation = cam.rotation;
        cam.parent = parent;
        cam.rotation = rotation;
    }
}
