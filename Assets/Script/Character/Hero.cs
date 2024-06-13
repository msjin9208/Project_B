using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : BaseCharacter, ICharacter.IBehavior
{
    public override void SetStat( CharacterStat stat )
    {
        base.SetStat( stat );
    }


    public async UniTask DoBehavior( )
    {

    }

    public void DoAnimation( string anim )
    {

    }
}
