using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class AppScene
{
    public enum SceneType
    {
        Entry,
        Battle,
    }

    static private AppScene instance;

    private Dictionary<SceneType, BaseScene>    _sceneDic;
    private BaseScene                           _currentScene;
    private SceneType                           _currentType;

    static public void Initialize( )
    {
        instance = new AppScene( );
        instance._sceneDic = new Dictionary<SceneType , BaseScene>( );
    }

    static public bool Add( SceneType sceneType )
    {
        Type type = Type.GetType( $"{sceneType}Scene" );

        if( null == type )
        {
            Debug.Log( $"{sceneType} type is Null !!! " );
            return false;
        }
        else
        {
            object create = System.Activator.CreateInstance( type );
            if( null != create && create is BaseScene )
            {
                BaseScene scene = (BaseScene) create;
                scene.Init( );

                instance._sceneDic.Add( sceneType, scene );
            }

            return true;
        }
    }

    static public bool Move( SceneType sceneType ) 
    {
        if( null != instance._currentScene )
        {
            instance._currentScene.Exit( );
            instance._currentScene = null;
        }

        if( false == instance._sceneDic.TryGetValue( sceneType, out instance._currentScene ))
        {
            return false;
        }
        else
        {
            instance._currentType = sceneType;
            instance._currentScene.Enter( );
            return true;
        }
    }

    static public bool Back( )
    {
        return Move( instance._currentType - 1 );
    }
}
