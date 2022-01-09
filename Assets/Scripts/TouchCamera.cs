using UnityEngine;

public class TouchCamera : MonoBehaviour
{

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    private Vector3 firstpoint;
    private Vector3 secondpoint;
    private float xAngle = 0.0f;
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f;
    private float yAngTemp = 0.0f;

    private void Start()
    {
        firstpoint = new Vector3(0, 0, 0);
        secondpoint = new Vector3(0, 0, 0);

        xAngle = 90.0f;
        yAngle = 0.0f;

        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;

                if (yAngle > 90 && yAngle < 270)
                    xAngle = xAngTemp - (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                else
                    xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;

                transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);

                //xAngle = ClampAngle(xAngle, minimumX, maximumX);
                //yAngle = ClampAngle(yAngle, minimumY, maximumY);
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

}