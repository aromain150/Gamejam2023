using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]SO_Pickup pickup;
    [SerializeField]Transform spawnpoint;
    GameObject model;
    bool canPickup = false;

    [SerializeField] GameObject Effect;

    [SerializeField] bool falling = false;


    private void Start()
    {
        if (falling)
        {
            StartCoroutine(SpawnRandomly());
        }
    }

    private void Update()
    {
        if (canPickup && !Effect.activeSelf)
        {
            Effect.SetActive(true);
        }
    }

    IEnumerator SpawnRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(15,30));
            SpawnModel();
        }
    }

    public string GetPickupType()
    {
        return pickup.id;
    }

    public void SpawnModel()
    {
        if (canPickup) return;

        Effect.SetActive(true);


        model = Instantiate(pickup.model, spawnpoint);

        if (falling)
        { model.transform.DOMove(spawnpoint.position, 3f).From(spawnpoint.position+Vector3.up * 40).SetEase(Ease.InSine).OnComplete(() => canPickup = true); }
        else 
        { model.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero); canPickup = true; }

   

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

        Effect?.SetActive(false);
    }
}
