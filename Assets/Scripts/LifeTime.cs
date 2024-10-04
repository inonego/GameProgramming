using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeTime : MonoBehaviour
{
    public float time = 10f;

    public UnityEvent onDestroy;

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);

        onDestroy.Invoke();

        Destroy(gameObject);
    }

    private void Awake()
    {
        StartCoroutine(Destroy());
    }
}
