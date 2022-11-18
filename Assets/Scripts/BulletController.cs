using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Transform circleOrigin;
    public float radius;

    private Vector2 lastPos;
    private Vector2 curPos;
    private Vector2 playerPos;


    void Start()
    {
        transform.localScale = new Vector2(0.32f, 0.32f);
    }

    void Update()
    {
        AttackPlayer();
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void AttackPlayer()
    {
        curPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
        if (curPos == lastPos)
        {
            Destroy(gameObject);
        }
        lastPos = curPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            HealthScript health;
            if (health = collision.GetComponent<HealthScript>())
            {
                health.GetHit(1, transform.gameObject);
            }
        }
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }


}
