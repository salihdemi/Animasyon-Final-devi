using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Transform cam, par;
    [SerializeField] GameObject robot;
    private void Awake()
    {
        cam = Camera.main.transform;
        par = cam.parent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cam.parent = null;
            par.gameObject.SetActive(false);
            robot.SetActive(true);
            StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {
        Vector3 target = new Vector3(0, 4.4f, 130);
        while (Vector3.Distance(cam.position, target) > 0.1f)
        {
            cam.position = Vector3.Lerp(cam.position, target, 0.01f);

            cam.LookAt(par);

            yield return null;
        }

    }
}
