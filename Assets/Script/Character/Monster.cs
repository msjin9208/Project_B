using CommonEnum;
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

    public int OnDamage( int dmg )
    {
        DoAnimation( AnimationType.Damage );

        int result  = dmg - Defense;
        result      = result < 1 ? 1 : result;

        Hp -= result;

        CheckDeath( );

        return result;
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
    public async UniTask DoBehavior( AnimationType type )
    {
        await DoAnimationWithWaiting(type);
    }
}