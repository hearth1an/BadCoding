using UnityEngine;

[RequireComponent (typeof(Transform))]
public class Mover : MonoBehaviour
{
    private Transform _placePoint;
    private Transform[] _places;

    private float _speed;
    private int _currentPlaceIndex;

    private int PlacePointChildCount => _placePoint.childCount;

    private void Start()
    {
        _places = new Transform[PlacePointChildCount];

        for (int i = 0; i < PlacePointChildCount; i++)
        {
            _places[i] = _placePoint.GetChild(i);
        }            
    }

    private void Update()
    {
        Transform pointNumber = _places[_currentPlaceIndex];

        transform.position = Vector3.MoveTowards(transform.position, pointNumber.position, _speed * Time.deltaTime);

        if (transform.position == pointNumber.position)
            ChooseNextPlace();
    }

    private void ChooseNextPlace()
    {
        int minPlaceIndex = 0;
        Vector3 pointVector = _places[_currentPlaceIndex].transform.position;

        _currentPlaceIndex++;

        if (_currentPlaceIndex == _places.Length)
            _currentPlaceIndex = minPlaceIndex;
        
        transform.forward = pointVector - transform.position;
    }
}