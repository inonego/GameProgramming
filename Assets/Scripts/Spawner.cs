using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float range = 20f;

    public int count = 5;

    public float interval = 1f;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = transform.position + new Vector3(Random.Range(range * -0.5f, range * +0.5f), 1f, Random.Range(range * -0.5f, range * +0.5f));

            Instantiate(prefab, position, Quaternion.identity);

            yield return new WaitForSeconds(interval);
        }
    }
}
