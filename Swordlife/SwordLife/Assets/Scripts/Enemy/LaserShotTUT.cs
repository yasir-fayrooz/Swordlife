using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotTUT : MonoBehaviour
{
    private Animator LaserShotAnim;

    void Start()
    {
        LaserShotAnim = gameObject.GetComponent<Animator>();
    }
    void TransitionToSecondAnim()
    {
        LaserShotAnim.SetBool("FinishWoosh", true);
    }
}
