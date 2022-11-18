using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Follow,
    
    Attack,

    Stay
};

public enum EnemyType
{
    Melee,

    Ranged
};

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    public EnemyState currentState = EnemyState.Follow;
    public EnemyType enemyType;

    public float speed;
    public float range;
    public float attackSpeed;
    public bool coolDownAttack;

    public GameObject bulletPref;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {

        switch (currentState)
        {
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Attack):
                Attack();
                break;
            case (EnemyState.Stay):
                Stay();
                break;
        }

        if (HealthScript.isDead) 
        {
            currentState = EnemyState.Stay;
        }

        if (!IsPlayerInRange(range) && !HealthScript.isDead) 
        {
            currentState = EnemyState.Follow;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= range && !HealthScript.isDead) 
        {
            currentState = EnemyState.Attack;
        }
    }

    void Follow()
    {
        Vector3 distance = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2f), 0);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position + distance, speed * Time.deltaTime);
    }

    void Attack() 
    {
        if (!coolDownAttack && !HealthScript.isDead)
        {
            GameObject bullet = Instantiate(bulletPref, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<BulletController>().GetPlayer(player.transform);
            StartCoroutine(CoolDown());
        }
    }

    void Stay() 
    {
        
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator CoolDown() 
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(attackSpeed);
        coolDownAttack = false;
    }
}
