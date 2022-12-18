using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplositon : MonoBehaviour
{

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
}