using UnityEngine;

[RequireComponent (typeof(Transform))]
public class GoPlaces : MonoBehaviour
{
    private Transform _placePoint;
    private Transform[] _places;

    private float _speed;
    private int _currentPlaceIndex;

    private int _placePointChildCount => _placePoint.childCount;

    private void Start()
    {
        _places = new Transform[_placePointChildCount];

        for (int i = 0; i < _placePointChildCount; i++)
        {
            _places[i] = _placePoint.GetChild(i).GetComponent<Transform>();
        }            
    }

    private void Update()
    {
        Transform pointNumber = _places[_currentPlaceIndex];

        transform.position = Vector3.MoveTowards(transform.position, pointNumber.position, _speed * Time.deltaTime);

        if (transform.position == pointNumber.position)
            GetNextPlace();
    }

    private Vector3 GetNextPlace()
    {
        int minPlaceIndex = 0;
        Vector3 pointVector = _places[_currentPlaceIndex].transform.position;

        _currentPlaceIndex++;

        if (_currentPlaceIndex == _places.Length)
            _currentPlaceIndex = minPlaceIndex;
        
        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}