using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootemUp : Character
{
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (nextShot <= 0f)
        {
            for (int i = 0; i < Guns.Count; i++)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    Fire(transform.GetChild(i).gameObject.transform, Direction.UP, "projectile");
                }
            }
            nextShot = Projectiles[(int)projectileType].GetComponent<Projectile>().ShotRatio;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = transform.position.y;
            touchPosition.z = transform.position.z;

            if (touchPosition.x < minValue)
                touchPosition.x = minValue;
            if (touchPosition.x > maxValue)
                touchPosition.x = maxValue;

            transform.position = Vector3.Lerp(transform.position, touchPosition, 0.1f);
        }
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("enemy"))
        {
            playerInfoRef.DecreaseLives();
            collision.gameObject.GetComponent<Interactable>().Remover();
            Remover();
        }
    }
}
