using ICharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : BaseCard, ICard.IAttack
{
    public bool Attack( BaseCharacter caster, BaseCharacter target )
    {
        int cardPower   = Power;
        int castPower   = caster.Power;
        int result      = cardPower + castPower;

        IDamage damage  = target as IDamage;

        if( null == damage )
            return false;
        
        damage.OnDamage( result );

        return true;
    }
}
