using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Ally,
    Enemy,
}

/// <summary>
/// Base
/// </summary>
public partial class BattleCore
{
    public BattleCore( )
    {
        _characterDic = new Dictionary<CharacterType , BaseCharacter>( );

        InitTurn( );
        InitWave( );
    }
}

/// <summary>
/// Controll Wave
/// </summary>
public partial class BattleCore
{
    private int _wave;

    private void InitWave( )
    {
        _wave = 0;
    }

    public void StartWave( )
    {

    }

    public void EndWave( )
    {

    }

    private void NextWave( )
    {
        ++_wave;
    }
}

/// <summary>
/// Controll Turn
/// </summary>
public partial class BattleCore
{
    private int _curTurn;
    
    private void InitTurn( )
    {
        _curTurn = 0;
    }

    public void StartTurn( )
    {

    }

    public void EndTurn( )
    {

    }

    private void NextTurn( )
    {
        ++_curTurn;
    }
}

/// <summary>
/// Controll Character
/// </summary>
public partial class BattleCore
{
    private Dictionary<CharacterType, BaseCharacter> _characterDic;

    
}
