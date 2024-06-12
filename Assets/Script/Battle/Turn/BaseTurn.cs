using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurn
{
    public void Enter( BaseCharacter character );
    public void Excute( );
    public void Exit( );
}

public abstract class BaseTurn : ITurn
{
    public virtual void Enter( BaseCharacter character ) { }
    public virtual void Excute( ) { }
    public virtual void Exit( ) { }
}
