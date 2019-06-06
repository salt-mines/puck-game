using UnityEngine;

// Credit: https://forum.unity.com/threads/setting-horizontal-fov-orthographic-size-of-the-camera.537911/
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class HorizontalCamera : MonoBehaviour
{
    private new Camera camera;
    private float lastAspect;

    [SerializeField]
    [Range(1.0f, 180f)]
    private float _fieldOfView = 60f;
    
    public float fieldOfView
    {
        get { return _fieldOfView; }
        set
        {
            if (_fieldOfView != value)
            {
                _fieldOfView = value;
                RefreshCamera();
            }
        }
    }

    private void OnEnable()
    {
        RefreshCamera();
    }

    private void Update()
    {
        float aspect = camera.aspect;
        if (aspect != lastAspect)
            AdjustCamera(aspect);
    }

    public void RefreshCamera()
    {
        if (camera == null)
            camera = GetComponent<Camera>();

        AdjustCamera(camera.aspect);
    }

    private void AdjustCamera(float aspect)
    {
        lastAspect = aspect;

        // Credit: https://forum.unity.com/threads/how-to-calculate-horizontal-field-of-view.16114/#post-2961964
        float _1OverAspect = 1f / aspect;
        camera.fieldOfView = 2f * Mathf.Atan(Mathf.Tan(_fieldOfView * Mathf.Deg2Rad * 0.5f) * _1OverAspect) * Mathf.Rad2Deg;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        RefreshCamera();
    }
#endif
}
