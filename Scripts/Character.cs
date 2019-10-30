using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Interactable
{
    protected List<Transform> Guns;
    protected float nextShot;

    [SerializeField]
    protected float minValue = 0f;
    [SerializeField]
    protected float maxValue = 0f;
    [SerializeField]
    protected GameObject[] Projectiles;
    [SerializeField]
    protected ProjectileType projectileType = ProjectileType.YELLOW;
    public void Fire(Transform origin, Direction dir, string tag)
    {
        GameObject currentProjectile = Projectiles[(int)projectileType];
        currentProjectile.tag = tag;
        currentProjectile.GetComponent<Projectile>().direction = dir;
        Instantiate(currentProjectile, origin.position, currentProjectile.transform.rotation);
    }
    public override void Start()
    {
        nextShot = 0f;
        Guns = new List<Transform>();
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.CompareTag("gun"))
                Guns.Add(child.transform);
        }
        base.Start();
    }
    public override void Update()
    {
        nextShot -= Time.deltaTime;
        base.Update();
    }
}
