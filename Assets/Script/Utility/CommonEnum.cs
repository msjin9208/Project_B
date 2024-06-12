namespace CommonEnum
{
    #region [ Scene ]
    public enum SceneType
    {
        Battle,
    }
    #endregion

    #region [ Battle ]
    public enum Camp
    {
        None,
        Ally,
        Enemy,
    }

    public enum CharacterType
    {
        Hero,
        Monster,
    }

    public enum TurnState
    {
        Stand       = 0,
        Start       = 1,
        Behavior    = 2,
        End         = 3,
    }
    #endregion
}