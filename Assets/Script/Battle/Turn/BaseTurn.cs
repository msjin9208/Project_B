using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurn
{
    public void Enter( );
    public void Excute( );
    public void Exit( );
}

public abstract class BaseTurn : ITurn
{
    protected TurnCore _core;
    public BaseTurn( TurnCore core )
    {
        _core = core;
    }

    public virtual void Enter( ) { }
    public virtual void Excute( ) { }
    public virtual void Exit( ) { }
}
