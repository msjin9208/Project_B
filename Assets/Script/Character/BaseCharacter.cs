using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseCharacter : MonoBehaviour, ICharacter.IAttack, ICharacter.IStat
{
    public string   NAME { get; private set; }
    public int      HP { get; private set; }
    public int      POWER { get; private set; }
    public int      DEFENCE { get; private set; }


    public virtual void SetStat( CharacterManager.CharacterStat stat )
    {
        NAME    = stat.name;
        HP      = stat.hp;
        POWER   = stat.power;
        DEFENCE = stat.defence;
    }

    public virtual void Attack( )
    {

    }
    public virtual void Defense( )
    {

    }
}
