using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (Kalkis.fps)
        {
            SceneManager.LoadScene(1);
        }
    }
}
