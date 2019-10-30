using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    STAR,
    YELLOW,
    RED
};

public class Projectile : Interactable
{
    [SerializeField]
    private float speed = 1f;

    public float ShotRatio = 1f;
    public Direction direction = Direction.UP;
    public ProjectileType type = ProjectileType.YELLOW;
    public string targetTag;

    // Update is called once per frame
    override public void Update()
    {
        Vector3 dir = Vector3.zero;
        float rotation = 0f;

        switch(direction)
        {
            case Direction.UP:
                dir = Vector3.up;
                rotation = 90f;
                break;
            case Direction.DOWN:
                dir = Vector3.down;
                rotation = -90f;
                break;
            case Direction.LEFT:
                dir = Vector3.left;
                break;
            case Direction.RIGHT:
                dir = Vector3.right;
                rotation = 180f;
                break;
        }
        myRigidBody.SetRotation(rotation);
        myRigidBody.MovePosition(transform.position + dir * speed * Time.deltaTime);

        base.Update();
    }
}

