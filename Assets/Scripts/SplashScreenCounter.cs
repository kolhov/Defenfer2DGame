using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SplashScreenCounter : MonoBehaviour
{
    [SerializeField] private int timeToWait = 3;
    void Start()
    {
        StartCoroutine(CorWaitAndLoad());
    }

    IEnumerator CorWaitAndLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        GetComponent<LevelLoader>().LoadNextScene();
    }
}
