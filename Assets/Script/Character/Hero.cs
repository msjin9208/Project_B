using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : BaseCharacter, ICharacter.IBuff
{
    public override void SetStat( CharacterManager.CharacterStat stat )
    {
        base.SetStat( stat );
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
