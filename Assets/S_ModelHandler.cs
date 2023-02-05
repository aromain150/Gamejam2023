using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ModelHandler : MonoBehaviour
{
    [SerializeField] GameObject Idle1;
    [SerializeField] GameObject Idle2;
    [SerializeField] GameObject Taken1;
    [SerializeField] GameObject Taken2;

    [SerializeField] int playerNum = 0;

    private void Awake()
    {
        ResetModels();
    }

    private void ResetModels()
    {
        Idle1.SetActive(false);
        Idle2.SetActive(false);
        Taken1.SetActive(false);
        Taken2.SetActive(false);
    }

    public void SetPlayer(int num)
    {
        playerNum = num;

        SetIdle();

    }

    public void SetIdle()
    {
        ResetModels();

        if (playerNum == 0) Idle1.SetActive(true);


        if (playerNum == 1) Idle2.SetActive(true);
    }

    public void SetHolding()
    {
        ResetModels();

        if (playerNum == 0) Taken1.SetActive(true);


        if (playerNum == 1) Taken2.SetActive(true);
    }

}
