using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handling of persons movement and infections
public class PersonHandler : MonoBehaviour
{
    public bool isDistancing = false;
    public bool isInfected = false;
    public float moveSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AddMotion();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDistancing)
        {
            AddMotion();
        }

        if (!isInfected)
        {
            PersonHandler otherPerson = collision.gameObject.GetComponent<PersonHandler>();

            if (otherPerson != null)
            {
                if (otherPerson.isInfected)
                {
                    Infect();
                }
            }
        }
    }

    public void AddMotion()
    {
        if (rb != null)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            Vector2 randomDirection = new Vector2(randomX, randomY).normalized;
            rb.velocity = randomDirection * moveSpeed;
        }
    }

    public void SetSocialDistancing(bool distancing)
    {
        if (rb != null)
        {
            if (distancing && !isDistancing)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                isDistancing = true;
            }
            else if (!distancing && isDistancing)
            {
                rb.isKinematic = false;
                AddMotion();
                isDistancing = false;
            }
        }
    }

    public void Infect()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            isInfected = true;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}