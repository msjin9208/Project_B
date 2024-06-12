using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBehavior : BaseTurn
{
    public override void Enter( BaseCharacter character )
    {
        base.Enter( character );

        Debug.Log( "Enter Behavior" );
    }

    public override void Excute( )
    {
        base.Excute( );
    }

    public override void Exit( )
    {
        base.Exit( );

        Debug.Log( "Exit Behavior" );
    }
}
