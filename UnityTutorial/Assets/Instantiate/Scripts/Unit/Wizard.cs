using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Unit
{
    public void Start()
    {
        health = 45;
        maxHealth = health;
        Debug.Log(health);
    }
}
