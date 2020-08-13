using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public enum Direction { Right, Left }

    #region Public properties



    #endregion

    #region Public methods

    public void SetDirection(Direction direction)
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = direction == Direction.Left ? 180 : 0;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    #endregion
}
