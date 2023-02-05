using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interact : MonoBehaviour
{
    public void InteractWithTerrier(int score)
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale, Quaternion.identity);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].TryGetComponent(out S_Terrier terrier))
            {
                if (terrier == null) return;
                terrier.SendScore(score);
            }
            i++;
        }
    }


}
