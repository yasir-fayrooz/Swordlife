using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

    public EdgeCollider2D[] colliders;

    // Use this for initialization
    void Start () {
        colliders = GetComponentsInChildren<EdgeCollider2D> ();
        colliders[0].enabled = false;
        colliders[1].enabled = false;
        colliders[2].enabled = false;
    }

    void DisableChildComponents()
    {
        colliders[0].enabled = false;
        colliders[1].enabled = false;
        colliders[2].enabled = false;
    }

    void swordCollider1()
    {
        colliders[1].enabled = false;
        colliders[2].enabled = false;
        colliders[0].enabled = true;
    }
    void swordCollider2()
    {
        colliders[0].enabled = false;
        colliders[2].enabled = false;
        colliders[1].enabled = true;
    }
    void swordCollider3()
    {
        colliders[0].enabled = false;
        colliders[1].enabled = false;
        colliders[2].enabled = true;
    }
}
