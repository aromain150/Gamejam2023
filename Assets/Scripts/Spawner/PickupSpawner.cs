using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickupSpawner : MonoBehaviour
{
    [SerializeField]SO_Pickup pickup;
    [SerializeField]Transform spawnpoint;
    GameObject model;
    bool canPickup = false;

    public string GetPickupType()
    {
        return pickup.id;
    }

    public void SpawnModel()
    {
        if (canPickup) return;

        model = Instantiate(pickup.model, spawnpoint);
        canPickup = true;
    }

    public SO_Pickup GetPickup()
    {
        if (!canPickup) return null;

        DespawnModel();
        return pickup;
    }

    void DespawnModel()
    {
        canPickup = false;
        Destroy(model);
    }
}
