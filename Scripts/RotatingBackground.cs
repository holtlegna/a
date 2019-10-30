using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
};

public class RotatingBackground : Item
{
    public Direction direction = Direction.DOWN;

    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        switch (direction)
        {
            case Direction.LEFT:
                myrenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
                break;
            case Direction.RIGHT:
                myrenderer.material.mainTextureOffset += new Vector2(-speed * Time.deltaTime, 0f);
                break;
            case Direction.UP:
                myrenderer.material.mainTextureOffset += new Vector2(0f, -speed * Time.deltaTime);
                break;
            case Direction.DOWN:
                myrenderer.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);
                break;
        }
    }
}

