using CommonEnum;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data" , menuName = "Character/Character Data", order = int.MaxValue)]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private int             _index;
    [SerializeField]
    private string          _name;
    [SerializeField]
    private int             _hp;
    [SerializeField]
    private int             _power;
    [SerializeField]
    private int             _defence;
    [SerializeField]
    private string          _resName;
    [SerializeField]
    private CharacterType   _characterType;

    #region Table
    public int              Index => _index;
    #endregion

    #region [ Stat ]
    public string           Name => _name;
    public int              HP => _hp;
    public int              Power => _power;
    public int              Defence => _defence;
    public CharacterType    CharacterType => _characterType;
    #endregion

    #region [ Resource ]
    public string           ResName => _resName;
    #endregion
}
