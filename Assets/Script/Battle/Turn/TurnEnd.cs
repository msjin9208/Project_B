using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TurnEnd : BaseTurn
{
    public TurnEnd(TurnCore core) : base(core) { }

    public override void Enter( BaseCharacter character )
    {
        base.Enter( character );

        Debug.Log( "Enter End" );
    }

    public override void Excute( )
    {
        base.Excute( );
    }

    public override void Exit( )
    {
        base.Exit( );

        Debug.Log( "Exit End" );
    }
}
