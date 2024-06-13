using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster : BaseCharacter, ICharacter.IBehavior, ICharacter.IDamage
{
    public override void SetStat( CharacterStat stat )
    {
        base.SetStat( stat );
    }

    public void OnDamage( int dmg )
    {
        Hp -= dmg;

        CheckDeath( );
    }

    public bool CheckDeath( ) 
    {
        Death = Hp <= 0;

        return Death;
    }
}

/// <summary>
/// Animation
/// </summary>
public partial class Monster
{
    public async UniTask DoBehavior( )
    {

    }

    public void DoAnimation( string anim )
    {

    }
}