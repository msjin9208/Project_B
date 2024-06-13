using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class BaseCharacter : MonoBehaviour , ICharacter.IStat
{
    public string   Name { get; protected set; }
    public int      Hp { get; protected set; }
    public int      MaxHp { get; protected set; }
    public int      Power { get; protected set; }
    public int      Defense { get; protected set; }
    public bool     Death { get; protected set; }


    public virtual void SetStat( CharacterStat stat )
    {
        Name    = stat.Name;
        Hp      = stat.Hp;
        MaxHp   = stat.Hp;
        Power   = stat.Power;
        Defense = stat.Defense;

        InitAnimator( );
    }
}

public partial class BaseCharacter
{
    protected Animator _animator;

    private void InitAnimator( )
    {
        if(false == TryGetComponent<Animator>( out _animator ))
        {
            Debug.Log( "Animator is not Available" );
        }
    }
}
