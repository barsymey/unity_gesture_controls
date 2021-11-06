using UnityEngine;
using UnityEngine.Events;

public class Swipe : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _endMagnitude;
    private float _xChange;
    private float _yChange;
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    
    public void SetStartPosition()
    {
        _startPosition = Input.mousePosition;
    }

    public void EndSwipe()
    {
        _endMagnitude = _startPosition - (Vector2)Input.mousePosition;
        if(_endMagnitude.x > 0)
        {
            OnSwipeRight.Invoke();
        }
        else
        {
            OnSwipeLeft.Invoke();
        }
        print(_endMagnitude);
    }
}
