using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class PlayerControls : MonoBehaviour
{
    public enum ControlMethods
    {
        Keys,
        Swipe,
        Drag
    }
    
    private Vector3 _posMax = new Vector3(6,0,0);
    private Vector3 _posMin = new Vector3(-6,0,0);
    private float _swipeDestination;

    [SerializeField] 
    private float speed = 0.1f;

    [SerializeField] 
    private EventSystem _eventSystem;

    [SerializeField] 
    private ControlMethods CurrentControl = ControlMethods.Keys;

    [SerializeField] 
    [Range(0f, 1f)] 
    private float lerpPct = 0.5f;
    // Start is called before the first frame update

    public void ChangeControls(ControlMethods method)
    {
        CurrentControl = method;
        if (CurrentControl == ControlMethods.Swipe)
        {
            _swipeDestination = lerpPct;
        }
    }

    public void ChangeDestination(bool dir) // moves right if true, else moves left
    {
        print(dir);

        if (dir)
        {
            _swipeDestination += 0.2f;
        }
        else
        {
            _swipeDestination -= 0.2f;
        }
        print(dir);
    }
    void Move()
    {
        switch (CurrentControl)
        {
            case ControlMethods.Keys:
                if (Input.GetAxis("Horizontal") > 0)
                {
                    lerpPct += speed*Time.deltaTime;
                }else if (Input.GetAxis("Horizontal") < 0)
                {
                    lerpPct -= speed*Time.deltaTime;
                }
                break;
            case ControlMethods.Drag:
                if (Input.GetMouseButton(0))
                {
                    _swipeDestination = Input.mousePosition.x / Screen.width;
                    if (lerpPct < _swipeDestination)
                    {
                        lerpPct += speed * Time.deltaTime;
                    }else                    
                    if (lerpPct > _swipeDestination)
                    {
                        lerpPct -= speed * Time.deltaTime;
                    }
                }
                break;
            case ControlMethods.Swipe:
                if(_swipeDestination - lerpPct > 0.05f || _swipeDestination - lerpPct < -0.05f)
                {
                    if (lerpPct > _swipeDestination)
                    {
                        lerpPct -= speed * Time.deltaTime;
                    }
                    else if (lerpPct < _swipeDestination)
                    {
                        lerpPct += speed * Time.deltaTime;
                    }
                }
                if (_swipeDestination > 1)
                {
                    _swipeDestination = 1;
                }else if (_swipeDestination < 0)
                {
                    _swipeDestination = 0;
                }
                break;
        }
        if (lerpPct > 1)
        {
            lerpPct = 1;
        }else if (lerpPct < 0)
        {
            lerpPct = 0;
        }
        transform.position = Vector3.Lerp(_posMin, _posMax, lerpPct);
    }

    void Update()
    {
        Move();
    }
}
