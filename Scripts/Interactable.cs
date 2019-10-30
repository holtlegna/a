using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Interactable : Item
{
    [SerializeField]
    protected GameObject ExplosionRef;
    protected Rigidbody2D myRigidBody;
    protected PlayerInfo playerInfoRef;

    // Start is called before the first frame update
    public override void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        playerInfoRef = GameObject.FindGameObjectWithTag("playerInfo").GetComponent<PlayerInfo>();
        base.Start();
    }

    public override void Update () { }

    public void Remover()
    {
        if (ExplosionRef)
            Instantiate(ExplosionRef, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
