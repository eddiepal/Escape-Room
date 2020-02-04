using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

//https://www.youtube.com/watch?v=CA2snUe7ARM Fantastic tutorial

public class Health : MonoBehaviourPun
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate {};

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    [PunRPC]
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float) currentHealth / (float) maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
            photonView.RPC("ModifyHealth", RpcTarget.All, -10);
    }
}
