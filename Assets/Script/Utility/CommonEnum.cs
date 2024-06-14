namespace CommonEnum
{
    #region [ Scene ]
    public enum SceneType
    {
        Battle,
    }
    #endregion

    #region [ Character ]
    public enum AnimationType
    {
        Idle,
        Attack,
        Damage,
    }
    #endregion

    #region [ Battle ]
    public enum Camp
    {
        None,
        Ally,
        Enemy,
    }

    public enum OnTarget
    {
        Self,
        Enemy,
    }

    public enum CharacterType
    {
        Hero,
        Monster,
    }

    public enum TurnState
    {
        None        = 0,
        Stand       = 1,
        Start       = 2,
        Behavior    = 3,
        End         = 4,
    }

    public enum CardType
    {
        None,
        Attack,
        Defense,
        Buff,
        Debuff
    }
    #endregion
}