using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private float updateRate = 1f;
    [SerializeField]
    private Vector2 amplitude = new Vector2(0.5f, 0.5f);
    [SerializeField]
    private int shootingChance = 50;
    public int Points = 10;

    private float nextUpdate = 0f;
    //public bool recentering = false;

    public override void Start()
    {
        shootingChance = Mathf.Max(0, Mathf.Min(shootingChance, 100));
        base.Start();
    }

    public override void Update()
    {
        nextUpdate -= Time.deltaTime;
        if(nextUpdate <= 0f)
        {
            Vector3 offset = Vector3.zero;
            switch (Random.Range(0, 2))
            {
                case 0:
                    offset = new Vector3(Random.Range(-amplitude.x, amplitude.x), 0f, 0f);
                    break;
                case 1:
                    offset = new Vector3(0f, Random.Range(-amplitude.y, 0), 0f);
                    break;
            }

            Vector3 newPosition = transform.position + offset;
            if (newPosition.x < minValue)
                newPosition.x = minValue;
            if (newPosition.x > maxValue)
                newPosition.x = maxValue;
            transform.position = newPosition;

            if (Random.Range(0,101) < shootingChance)
            {
                Fire(transform.GetChild(0),Direction.DOWN,"bullet");
            }
            nextUpdate = updateRate;
        }
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            playerInfoRef.AddPoints(Points);
            collision.gameObject.GetComponent<Interactable>().Remover();
            Remover();
        }
        if(collision.gameObject.CompareTag("bullet"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
