using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{

    public GameObject proj;
    public IAbility currentAbility;

    void Start()
    {
        currentAbility = new Ability();
        currentAbility.proj = proj;
        currentAbility.Use();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentAbility.Use();
        }
    }
}
