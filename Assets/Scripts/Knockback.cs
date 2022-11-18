using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Knockback : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;

    [SerializeField]
    private float strength = 16, delay = 0.15f;

    [SerializeField]
    Color32 getHitColor = new Color32(1, 1, 1, 1), deafultColor = new Color32(1, 1, 1, 1);

    public UnityEvent OnBegin, OnDone;

    public AudioSource hit;


    public void Play(GameObject sender) 
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb2d.AddForce(direction*strength, ForceMode2D.Impulse);
        gameObject.GetComponent<SpriteRenderer>().color = getHitColor;
        hit.Play();
        StartCoroutine(Reset());
    }

    private IEnumerator Reset() 
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        gameObject.GetComponent<SpriteRenderer>().color = deafultColor;
        OnDone?.Invoke();
    }
}
