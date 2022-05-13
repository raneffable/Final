using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float cdAttack;
    private Animator anim;
    private Player_Move pmove;
    private float cdTimer =Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pmove = GetComponent<Player_Move>();
    }
    
    private void Update()
    {
        if(Input.GetKey(KeyCode.C) && cdTimer > cdAttack && pmove.slashAtt())
        {
            Attack();
        }
        cdTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cdTimer = 0;
    }
}
