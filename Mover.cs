using UnityEngine;

[RequireComponent (typeof(Transform))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _placePoint;
    [SerializeField] private float _speed;

    private Transform[] _places;
    
    private int _currentPlaceIndex;

    public int PlacePointChildCount => _placePoint.childCount;

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
            ChooseNextPlaceAndRotate();
    }

    private void ChooseNextPlaceAndRotate()
    {
        int minPlaceIndex = 0;
        Vector3 pointVector = _places[_currentPlaceIndex].transform.position;

        _currentPlaceIndex++;

        if (_currentPlaceIndex == _places.Length)
            _currentPlaceIndex = minPlaceIndex;
        
        transform.forward = pointVector - transform.position;
    }


}