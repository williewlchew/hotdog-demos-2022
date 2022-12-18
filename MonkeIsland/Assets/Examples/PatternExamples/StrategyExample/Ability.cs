using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour, IAbility
{
    private GameObject projp;

    public GameObject proj{
        get => projp;
        set => projp = value;
    }

    public void Use()
    {
        Instantiate(proj, new Vector3(0,0,0), Quaternion.Euler(0, 0, 0));
    }
}