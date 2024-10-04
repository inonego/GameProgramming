using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionReference inputAction;

    public GameObject bullet;

    public Transform shootPoint;

    public float coolDownTime = 3f;

    private bool isFiring = false;

    private bool isCoolDown = false;

    private void Update()
    {
        if (inputAction != null)
        {
            if (inputAction.action.WasPressedThisFrame())
            {
                isFiring = true;
            }

            if (inputAction.action.WasReleasedThisFrame())
            {
                isFiring = false;
            }

            if (isFiring && !isCoolDown)
            {
                StartCoroutine(DoFire());
            }
        }
    }

    private IEnumerator DoFire()
    {
        while (isFiring)
        {
            Fire();

            isCoolDown = true;

            yield return new WaitForSeconds(coolDownTime);

            isCoolDown = false;
        }
    }

    public void Fire()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }

}
