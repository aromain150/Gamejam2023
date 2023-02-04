using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups", order = 2, fileName = "Pickup")]
public class SO_Pickup : ScriptableObject
{
     [field: SerializeField] public string id { get; private set; }
     [field: SerializeField] public GameObject model { get; private set; }
     [field: SerializeField] public int points { get; private set; }
     [field: SerializeField] public float heaviness { get; private set; }
}
