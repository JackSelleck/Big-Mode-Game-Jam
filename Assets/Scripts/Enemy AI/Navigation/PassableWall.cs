using System;
using UnityEngine;

public class PassableWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
        }
    }
}
