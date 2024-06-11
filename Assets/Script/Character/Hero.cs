using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : BaseCharacter, ICharacter.IBuff
{
    public override void SetStat( )
    {
        base.SetStat( );
    }

    public override void Attack( )
    {
        base.Attack( );
    }

    public override void Defense( )
    {
        base.Defense( );
    }

    public virtual void Buff( )
    {

    }
    public virtual void Debuff( )
    {

    }
}
