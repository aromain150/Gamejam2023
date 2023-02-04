using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PickupPoint : MonoBehaviour
{
    bool hasModel = false;
    GameObject currentModel;

    public void AddModel(GameObject model)
    {
        if (hasModel) return;
        currentModel = Instantiate(model,transform);
        hasModel = true;
    }

    public void RemoveModel()
    {
        if (!hasModel) return;
        Destroy(currentModel);
        hasModel = false;
    }

}
