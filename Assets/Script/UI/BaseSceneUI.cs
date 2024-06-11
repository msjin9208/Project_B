using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneUI
{
    void Init( );
    void Enter( );
    void Exit( );
    void DataReset( );
    void SetActive( bool active );
}

public class BaseSceneUI : MonoBehaviour, ISceneUI
{
    public virtual void Init( ) { }
    public virtual void Enter( ) { SetActive( true ); }
    public virtual void Exit( ) { SetActive( false ); }
    public virtual void DataReset( ) { }
    public virtual void SetActive( bool active ) { gameObject.SetActive( active ); }
}
