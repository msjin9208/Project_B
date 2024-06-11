using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public bool Active => gameObject.activeSelf;

    public virtual void Init( ) { }
    public virtual void Apply( ) { }
    public virtual void Despawn( ) { }
}
