using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Attacker_script : MonoBehaviour
{
    Vector3 myVector;
    public Animator animator;
    public float maxHP = 5;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        myVector = new Vector3(12.0f, 0.0f, 0.0f);
        HP = maxHP;
    }

    public void btnAtt()
    {
        DamagePopUp.Create(myVector, 1);
        TakeHit(1);
        animator.SetTrigger("Attack");
    }
    public void TakeHit(float dmg)
    {
        HP -= dmg;
        if (HP < 0)
        {
            Destroy(GameObject.Find("Enemy"));
        }
    }
}
