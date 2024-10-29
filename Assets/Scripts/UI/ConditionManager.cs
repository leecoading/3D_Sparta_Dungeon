using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    private void Start()
    {
        health = GetComponent<Condition>();
        stamina = GetComponent<Condition>();
    }


}
