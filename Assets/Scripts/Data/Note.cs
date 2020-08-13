
using System;
using UnityEngine;

[Serializable]
public class Note
{
    #region Public properties

    /// <summary>
    /// The note label
    /// </summary>
    public string Label;

    /// <summary>
    /// The note content
    /// </summary>
    [TextArea]
    public string Content;

    #endregion
}
