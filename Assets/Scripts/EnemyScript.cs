using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer spriteRenderer;
    public void die()
    {
        Destroy(this);

    }
}
