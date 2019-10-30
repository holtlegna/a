using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : Interactable
{
    [SerializeField]
    protected float speed = 1f;

    public override void Update()
    {
        myRigidBody.MovePosition(transform.position + Vector3.down * speed * Time.deltaTime);
        base.Update();
    }

    public abstract void Pick(GameObject playerRef);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Pick(collision.gameObject);
            Remover();
        }
    }
}
