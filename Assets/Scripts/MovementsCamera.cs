using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsCamera : MonoBehaviour
{
    public float sensivity;

    public CreatingMap creatingMap;

    public Vector2 offsetLimit;

    private Vector3 _startTouch;

    [SerializeField] private GameObject _bannerActive;

    void Update()
    {
        if(!_bannerActive.activeSelf)//если баннер в неактиве
        {
            Click();//если мы кликнули по экрану

            Hold();//если мы удерживаем
        }

    }
    public void Click()
    {
        if (Input.GetMouseButtonDown(0)) _startTouch = Input.mousePosition;
    }

    public void Hold()
    {
        if (Input.GetMouseButton(0))
        {
            float nextPosX = (transform.position + ((Input.mousePosition - _startTouch) * sensivity)).x;
            float nextPosY = (transform.position + ((Input.mousePosition - _startTouch) * sensivity)).y;

            float X = Mathf.Clamp(nextPosX, creatingMap.limitXleft - offsetLimit.x, creatingMap.limitXright + offsetLimit.x);

            float Y = Mathf.Clamp(nextPosY, creatingMap.limitYup - offsetLimit.y, creatingMap.limitYdown + offsetLimit.y);

            transform.position = new Vector3(X, Y, -10);
        }
    }
}
