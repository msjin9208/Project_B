using ICharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : BaseCard, ICard.IAttack
{
    public int Attack( BaseCharacter caster, BaseCharacter target )
    {
        int cardPower   = Power;
        int castPower   = caster.Power;
        int dmg         = cardPower + castPower;

        IDamage damage  = target as IDamage;

        if( null == damage )
            return 0;
        
        int result = damage.OnDamage( dmg );

        return result;
    }
}
