using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speedFly;
    [SerializeField] Transform transfPlanet;
    [SerializeField] Rigidbody2D rgbody;

    Vector2 _vecPrePosition;
    Vector2 _vecCurPosition;
    Vector2 _vecOriginPostion;
    
    void Start()
    {
        //_vecOriginPostion = transform.position;
        Vector2 vecForceFly = new Vector2(1f, 1f);
        rgbody.AddForce(vecForceFly, ForceMode2D.Impulse);
    }
    float _totalTimeFly = 4f;

    void Update()
    {
        //Vector3 vec = Vector3.right * speedFly * Time.deltaTime;
        //_vecPrePosition = transform.position;
        ////TranslateRocket(vec);
        ////LerpRocket(_vecOriginPostion, transfPlanet.position, Time.time / _totalTimeFly);'
        //SlerpRocket(_vecOriginPostion, transfPlanet.position, Time.time / _totalTimeFly);
        //_vecCurPosition = transform.position;
        //Direction(_vecPrePosition, _vecCurPosition);
    }

    /// <summary>
    /// Hướng di chuyển của tên lửa
    /// </summary>
    /// <param name="vecPointFrom"></param>
    /// <param name="vecPointTo"></param>
    void Direction(Vector2 vecPointFrom, Vector2 vecPointTo)
    {
        Vector2 vecDirect = vecPointTo - vecPointFrom;
        if (vecDirect == Vector2.zero)
            return;
        float angle = Mathf.Atan2(vecDirect.y, vecDirect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    /// <summary>
    /// Thay đổi vị trí của tên lửa sử dụng hàm Translate
    /// </summary>
    /// <param name="translation"></param>
    void TranslateRocket(Vector3 translation)
    {
        transform.Translate(translation, Space.World);
    }

    /// <summary>
    /// Thay đổi vị trí từ điểm đầu đến điểm cuối theo thời gian
    /// </summary>
    /// <param name="vecFrom"></param>
    /// <param name="vecTo"></param>
    void LerpRocket(Vector3 vecFrom, Vector3 vecTo, float t)
    {
        transform.position = Vector3.Lerp(vecFrom, vecTo, t);
    }

    /// <summary>
    /// Điều chỉnh tên lửa bay theo vòng cung 
    /// </summary>
    /// <param name="vecFrom"></param>
    /// <param name="vecTo"></param>
    /// <param name="t"></param>
    void SlerpRocket(Vector3 vecFrom, Vector3 vecTo, float t)
    {
        transform.position = Vector3.Slerp(vecFrom, vecTo, t);
    }

    Vector2 _vecMouse, _vecDistance;
    private void OnMouseDown()
    {
        _vecMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _vecDistance = _vecMouse - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        _vecMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _vecMouse - _vecDistance;
    }
}
