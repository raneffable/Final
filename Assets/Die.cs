using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public Animator animator;
    public float maxHP = 5;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeHit(float dmg)
    {
        HP -= dmg;
        if (HP < 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject);
        }
    }
}
