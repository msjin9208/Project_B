using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStart : BaseTurn
{
    public TurnStart(TurnCore core) : base(core) { }
    public override void Enter( )
    {
        base.Enter( );

        Debug.Log( "Enter Start" );

        _core.NextState( );
    }

    public override void Excute( )
    {
        base.Excute( );
    }

    public override void Exit( )
    {
        base.Exit( );

        Debug.Log( "Exit Start" );
    }
}
