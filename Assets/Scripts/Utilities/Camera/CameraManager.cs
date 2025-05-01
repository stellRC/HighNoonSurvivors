using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // singleton since there will only ever be one
    public static CameraManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
