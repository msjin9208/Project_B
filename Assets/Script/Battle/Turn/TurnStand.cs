using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStand : BaseTurn
{
    public TurnStand(TurnCore core) : base(core) { }
    public override void Enter( BaseCharacter character )
    {
        base.Enter( character );

        Debug.Log( "Enter Stand" );
    }

    public override void Excute( )
    {
        base.Excute( );
    }

    public override void Exit( )
    {
        base.Exit( );

        Debug.Log( "Exit Stand" );
    }

}
