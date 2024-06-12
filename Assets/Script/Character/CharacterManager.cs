using CommonEnum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public partial class CharacterManager
{
    static private CharacterManager _instance;
    static public CharacterManager Instance
    {
        get
        {
            if( null == _instance )
            {
                _instance = new CharacterManager( );
                _instance.Init( );
            }

            return _instance;
        }
    }

    private void Init( )
    {
        _characterData  = new Dictionary<int , CharacterData>( );

        AddCharacterData( "Hero" );
        AddCharacterData( "Monster1" );
    }
}

/// <summary>
/// Character Data
/// </summary>
public partial class CharacterManager
{
    public struct CharacterStat
    {
        public string   name;
        public int      hp;
        public int      power;
        public int      defence;
    }

    private readonly string                 _dataPath = "Characters/Data/";

    private Dictionary<int, CharacterData>  _characterData;

    private void AddCharacterData( string res )
    {
        CharacterData data = Resources.Load<CharacterData>( _dataPath + res );
        _characterData.Add( data.Index , data );
    }

    private CharacterStat GetStat( int idx )
    {
        if( false == _characterData.TryGetValue( idx, out var data ) )
        {
            return default;
        }
        else
        {
            CharacterStat stat = new CharacterStat( );
            stat.name       = data.Name;
            stat.hp         = data.HP;
            stat.power      = data.Power;
            stat.defence    = data.Defence;

            return stat;
        }
    }
}

/// <summary>
/// Create
/// </summary>
public partial class CharacterManager
{
    private readonly string  _prefabPath = "Characters/Prefab/";

    public BaseCharacter MakeByCharacter( int idx, Transform parent )
    {
        if( false == _characterData.TryGetValue( idx , out var data ) )
        {
            return null;
        }
        else
        {
            BaseCharacter character = OnLoadPrefab( data, parent );
            return character;
        }
    }

    private BaseCharacter OnLoadPrefab( CharacterData data, Transform parent )
    {
        GameObject go = Resources.Load<GameObject>( _prefabPath + data.ResName );
        if( null == go )
        {
            return null;
        }

        GameObject create       = GameObject.Instantiate( go, parent );
        System.Type type        = CreateData( data.CharacterType );
        BaseCharacter character = create.AddComponent( type ) as BaseCharacter;
        CharacterStat stat      = GetStat( data.Index );

        character.SetStat( stat );

        return character;
    }

    private System.Type CreateData( CharacterType type )
    {
        System.Type getType = default;
        switch( type )
        {
            case CharacterType.Hero:
                {
                    getType = typeof( Hero );
                }
                break;
            case CharacterType.Monster:
                {
                    getType = typeof( Monster );
                }
                break;
        }

        return getType;
    }
}