using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightClose : MonoBehaviour
{
    [SerializeField] private Light lightx;
    [SerializeField] private float dark1, light1, dark2, light2;
    void Start()
    {
        StartCoroutine(d1());
    }




    IEnumerator d1()
    {
        float timex = 0;
        lightx.enabled = false;
        while (timex <= dark1)
        {
            timex += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(l1());
    }
    IEnumerator l1()
    {
        float timex = 0;
        lightx.enabled = true;
        while (timex <= light1)
        {
            timex += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(d2());
    }
    IEnumerator d2()
    {
        float timex = 0;
        lightx.enabled = false;
        while (timex <= dark2)
        {
            timex += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(l2());
    }
    IEnumerator l2()
    {
        float timex = 0;
        lightx.enabled = true;
        while (timex <= light2)
        {
            timex += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(d1());
    }


}
