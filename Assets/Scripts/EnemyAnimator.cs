using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public AudioSource swish;

    public void SwishSound() 
    {
        swish.Play();
    }

}
