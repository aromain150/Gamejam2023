using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

[Serializable]
public class SpawnEvent{
    public float seconds;
    public string SpawnEventName;
}

public class PickupSpawnerManager : MonoBehaviour
{
    public static PickupSpawnerManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] List<SpawnEvent> spawnEvents;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawnSequence();
    }

    // Update is called once per frame
    public void StartSpawnSequence()
    {
        StartCoroutine(SpawnSequence());
    }

    IEnumerator SpawnSequence()
    {
        for (int i = 0; i < spawnEvents.Count; i++)
        {
            yield return new WaitForSeconds(spawnEvents[i].seconds);
            MMGameEvent.Trigger(spawnEvents[i].SpawnEventName);
        }
    }
}
