using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kalkis : MonoBehaviour
{
    [SerializeField] private float height;
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
        Vector3 target = new Vector3(transform.position.x, height, transform.position.y);

        while (transform.position.y + 0.1f <= height)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.01f);
            yield return null;
        }
        ChangeState();
    }
    void ChangeState()
    {
        GetComponent<Fps>().enabled = true;
        fakeBody.SetActive(true);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        enabled = false;
    }
}
