using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Item : MonoBehaviour
{
    protected Renderer myrenderer;
    // Start is called before the first frame update
    public virtual void Start()
    {
        myrenderer = gameObject.GetComponent<Renderer>();
    }

    public abstract void Update();
}


