using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    private Transform[] _points;

    private int _currentIndex;

    [SerializeField] private float _speed = 2;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0, l = _points.Length; i < l; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        

        Transform currentTarget = _points[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
        {
            if (++_currentIndex >= _points.Length)
            {
                _currentIndex = 0;
            }
        }
    }
}
