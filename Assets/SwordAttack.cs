using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordColl;
 
    Vector2 rightAttackOffset;
    public float damage = 3;
    private void Start()
    {
        rightAttackOffset = transform.position;   
    }

    public void AttackRight() {
        //print("Right");
        swordColl.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft() {
        //print("Left");
        swordColl.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordColl.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") {
            //Debug.Log("You Hit Enemy");
            // print("Woi");
            EnemyScript enemy = other.GetComponent<EnemyScript>();

            enemy.Health -= damage;
        }
    }
    

}
