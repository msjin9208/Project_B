using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public enum UIType
    {
       Battle,
       Max,
    }

    #region > SETTING <
    Camera                              _mainCamera;
    Canvas                              _canvas;
    EventSystem                         _eventSystem;
    #endregion

    #region > TRANS <
    RectTransform                       _rectTransform;

    GameObject                          _uiGo;
    GameObject                          _popGo;
    #endregion

    #region > PARAMETER <
    readonly string                     _resPath = "UIs";
    #endregion

    #region > DATA <
    BaseSceneUI[]                       _sceneUI;
    #endregion

    public MainUI()
    { 
        instance            = this;
        instance._sceneUI   = new BaseSceneUI[(int)UIType.Max];
    }

    private void Initailize( )
    {
        InitCamera( );
        InitCanvas( );
        InitCanvasScaler( );
        InitGraphicRaycaster( );
        InitTransform( );
    }

    private void InitCamera( )
    {
        _mainCamera                 = gameObject.AddComponent<Camera>( );
        _mainCamera.clearFlags      = CameraClearFlags.Nothing;
        _mainCamera.orthographic    = true;
    }

    private void InitCanvas( )
    {
        _canvas             = gameObject.AddComponent<Canvas>( );

        _canvas.worldCamera = _mainCamera;
        _canvas.renderMode  = RenderMode.ScreenSpaceOverlay;
    }

    private void InitGraphicRaycaster()
    {
        var graph           = gameObject.AddComponent<GraphicRaycaster>();
    }
    private void InitCanvasScaler()
    {
        var scaler                  = gameObject.AddComponent<CanvasScaler>();
        scaler.uiScaleMode          = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.screenMatchMode      = CanvasScaler.ScreenMatchMode.Expand;
        scaler.referenceResolution  = new Vector2( 1080 , 1920 );
    }

    private void InitTransform( )
    {
        _uiGo = new GameObject("UIs");
        {
            _uiGo.transform.SetParent( instance.transform );

            RectTransform uiTransform = _uiGo.AddComponent<RectTransform>( );
            {
                uiTransform.offsetMin = Vector2.zero;
                uiTransform.offsetMax = Vector2.zero;
                uiTransform.anchorMin = Vector2.zero;
                uiTransform.anchorMax = Vector2.one;
            }

            _uiGo.transform.localPosition = Vector3.zero;
            _uiGo.transform.localScale = Vector3.one;
        }

        _popGo = new GameObject("Popup");
        {
            _popGo.transform.SetParent( instance.transform );

            RectTransform popupTransform = _popGo.AddComponent<RectTransform>( ) ;
            {
                popupTransform.offsetMin = Vector2.zero;
                popupTransform.offsetMax = Vector2.zero;
                popupTransform.anchorMin = Vector2.zero;
                popupTransform.anchorMax = Vector2.one;
            }

            _popGo.transform.localPosition = Vector3.zero;
            _popGo.transform.localScale= Vector3.one;
        }

        GameObject go = new GameObject( "EventSystem" );
        {
            _eventSystem = go.AddComponent<UnityEngine.EventSystems.EventSystem>( );

            go.AddComponent<StandaloneInputModule>( );

            _eventSystem.transform.SetParent( instance.transform );
        }
    }

    private T MakebySceneUI<T>( UIType type ) where T : BaseSceneUI
    {
        string resPath  = $"{_resPath}/{type}SceneUI";

        GameObject res = Resources.Load<GameObject>(resPath);

        if( null == res )
            return null;

        GameObject go = Instantiate<GameObject>( res , _uiGo.transform );

        if( false == go.TryGetComponent<T>( out var ui ) )
            return null;

        _sceneUI[(int)type] = ui;

        return ui as T;
    }


    #region > STATIC <
    static MainUI instance;
    static public void Initialize( ) 
    {
        instance.Initailize( );
    }

    static public void Destroy( ) 
    {
        if( null == instance )
            return;

        GameObject.Destroy( instance.gameObject );
        instance = null;
    }

    static public T GetUI<T>( UIType type ) where T : BaseSceneUI
    {
        BaseSceneUI ui = instance._sceneUI[(int)type];
        if( null == ui )
        {
            ui = instance.MakebySceneUI<T>( type );
        }
        else
        {
            ui.transform.SetParent( instance._uiGo.transform );
        }

        return ui as T;
    }
    #endregion
}
