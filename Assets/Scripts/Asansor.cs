using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asansor : MonoBehaviour
{
    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartMove();
    }
    void StartMove()
    {
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveDown()
    {
        float timex = 0;
        while (startPos.y - timex >= 5)
        {
            timex += Time.deltaTime;
            transform.position = new Vector3(startPos.x, startPos.y-timex, startPos.z);
            yield return null;
        }
        SceneManager.LoadScene(2);
    }
}
