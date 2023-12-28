using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorceress : Unit
{
    public void Start()
    {
        health = 30;
        maxHealth = health;

        Debug.Log(health);
    }
}
