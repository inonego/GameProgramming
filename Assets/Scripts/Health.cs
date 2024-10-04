using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp = 0;

    public UnityEvent<int> onDamaged;
    public UnityEvent onDead;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            hp = Mathf.Max(hp - damage, 0);

            onDamaged.Invoke(damage);

            if (hp == 0)
            {
                onDead.Invoke();

                Destroy(gameObject);
            }
        }
    }
}
