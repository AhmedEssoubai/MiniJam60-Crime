using System;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    #region Serialize properties

    /// <summary>
    /// The followed character / object
    /// </summary>
    [SerializeField]
    private GameObject followed;

    /// <summary>
    /// The zone the camera don't interact
    /// </summary>
    [SerializeField]
    private float freeZoneRadius;

    /// <summary>
    /// The camera speed to followed the character
    /// </summary>
    [SerializeField]
    private float cameraSpeed;

    #endregion

    #region Public properties

    /// <summary>
    /// Is the camera followes the character
    /// </summary>
    public bool IsFollowing;

    #endregion

    #region Unity methods

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing && Math.Abs(followed.transform.position.y - transform.position.y) > freeZoneRadius)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + cameraSpeed * Time.deltaTime * Math.Sign(followed.transform.position.y - transform.position.y)
                , transform.position.z);
        }
    }

    #endregion
}
