using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    enum Conditions
    {
        CT_NONE,
        CT_BEGAN,
        CT_MOVED,
        CT_CANCELED,
        CT_ENDED,
        CT_STATIONARY
    };

    private Rigidbody _rigidbody;
    public float Speed;
    private Touch _touch;
    private Conditions _currentCondition;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentCondition = Conditions.CT_NONE;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    _currentCondition = Conditions.CT_BEGAN;
                    break;
                case TouchPhase.Moved:
                    _currentCondition = Conditions.CT_MOVED;
                    break;
                case TouchPhase.Canceled:
                    _currentCondition = Conditions.CT_CANCELED;
                    break;
                case TouchPhase.Ended:
                    _currentCondition = Conditions.CT_ENDED;
                    break;
                case TouchPhase.Stationary:
                    _currentCondition = Conditions.CT_STATIONARY;
                    break;
                default:
                    _currentCondition = Conditions.CT_NONE;
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        switch (_currentCondition)
        {
           case Conditions.CT_BEGAN:
                break;
           case Conditions.CT_MOVED:
               _rigidbody.velocity = new Vector3(_touch.deltaPosition.x * Speed * Time.fixedDeltaTime,
                   transform.position.y,
                   _touch.deltaPosition.y * Speed * Time.fixedDeltaTime);
               break;
           case Conditions.CT_CANCELED:
               break;
           case Conditions.CT_ENDED:
               _rigidbody.velocity = Vector3.zero;
               break;
           case Conditions.CT_STATIONARY:
               break;
           case Conditions.CT_NONE:
               break;
        }
    }
}