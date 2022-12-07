using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] LineRenderer linePrefab;

    int _countIndex;
    Vector2 _vecOrigin;
    Vector2 _vecDrag;
    Vector2 _vecCheck;
    bool _firstSpawn;
    LineRenderer _line;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _vecOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _vecCheck = _vecOrigin;
            transform.position = _vecOrigin;
        }
        if (Input.GetMouseButton(0))
        {
            if (!_firstSpawn)
            {
                _line = Instantiate(linePrefab, _vecOrigin, Quaternion.identity);
                _firstSpawn = true;
            }
            _vecDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (_vecCheck != _vecDrag)
            {
                _countIndex++;
                _line.positionCount = _countIndex + 1;
                _line.SetPosition(_countIndex, _vecDrag - _vecOrigin);
                _vecCheck = _vecDrag;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _countIndex = 0;
            _firstSpawn = false;
        }
    }

}
