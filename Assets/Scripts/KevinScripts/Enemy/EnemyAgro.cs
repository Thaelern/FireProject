using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    public GameObject player;

    public float speed;
    public float AgroRange;    
    private float distance;

    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    private void Start()
    {
        
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;   

       

        if (distance < AgroRange)
        { 
          transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
          transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

        else
        { 
            canAttack += Time.deltaTime; 
        }
    }




    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
              other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f; 
            }
            else
            {
                canAttack += Time.deltaTime;
            }
            
        }
    }




}
