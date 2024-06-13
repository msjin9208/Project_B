using CommonEnum;
using System.Collections.Generic;
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
                _instance.Initialize( );
            }

            return _instance;
        }
    }

    private void Initialize( )
    {
        _characterData  = new Dictionary<int , CharacterStat>( );

        AddCharacterData( "HeroStatData" );
        AddCharacterData( "MonsterStatData" );
    }
}

/// <summary>
/// Character Data
/// </summary>
public partial class CharacterManager
{
    private readonly string                 _dataPath = "Characters/Data/";

    private Dictionary<int, CharacterStat>  _characterData;

    private void AddCharacterData( string res )
    {
        CharacterData data = Resources.Load<CharacterData>( _dataPath + res );

        CharacterStat[] stats = data.CharacterStats;

        for( int i = 0; i < stats.Length; i++ )
        {
            CharacterStat stat = stats[i];
            if( _characterData.ContainsKey( stat.Index ) )
            {
                Debug.Log( $"Has been Stat {stat.Index}" );
                continue;
            }

            _characterData.Add( stat.Index , stat );
        }
    }

    private CharacterStat GetStat( int idx )
    {
        if( false == _characterData.TryGetValue( idx, out var data ) )
        {
            return default;
        }
        else
        {
            return data;
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

    private BaseCharacter OnLoadPrefab( CharacterStat data, Transform parent )
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