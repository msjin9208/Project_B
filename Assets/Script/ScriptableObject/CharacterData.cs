using CommonEnum;
using UnityEngine;

[System.Serializable]
public struct CharacterStat
{
    public int              Index;
    public string           Name;
    public int              Hp;
    public int              Power;
    public int              Defense;
    public string           ResName;
    public CharacterType    CharacterType;
}

[CreateAssetMenu(fileName = "Character Data" , menuName = "Character/Character Data", order = int.MaxValue)]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private CharacterStat[] _characterStat;

    public CharacterStat[]  CharacterStats => _characterStat;
}
