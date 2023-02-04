using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PickupRadar : MonoBehaviour
{
    [field: SerializeField] public PickupSpawner currentPickUpSpawner{ get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickupSpawner pickup))
        {
            currentPickUpSpawner = pickup;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PickupSpawner pickup))
        {
            if (currentPickUpSpawner != pickup) return;

            currentPickUpSpawner = null;
        }
    }

}
