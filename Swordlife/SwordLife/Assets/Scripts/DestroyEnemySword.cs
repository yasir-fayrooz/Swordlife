using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemySword : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
