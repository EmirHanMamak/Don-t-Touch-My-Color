using System;
using System.Collections;
using Core;
using Core.Camera;
using Core.Canvas;
using Core.Level;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
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

    public CameraShack CameraShackVar;
    public UIManager UIManagerVar;
    [Range(20,40)]
    public float Speed;
    public GameObject cam;
    public GameObject [] Furtures;
    [SerializeField] private GameObject[] bounderVector;
    [SerializeField] private RewardedAds _rewardedAds;
    private Rigidbody _rigidbody;
    private Touch _touch;
    private Conditions _currentCondition;
    private LevelDesignController _levelDesignController;
    private static int _firstFinger = 0, _secondFinger = 1, _thirdFinger = 2, _fourthFinger = 3;
    public bool workOnce;
    private void Awake()
    {
        workOnce = false;
        _rigidbody = GetComponent<Rigidbody>();
        _currentCondition = Conditions.CT_NONE;
        Variables.GameCondition = Variables.GC_NONE;
    }
    private void Update()
    {
        if (Variables.firstTouch == 1)
        {
            transform.position += new Vector3(0f, 0f, Variables.fowardsSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * Time.deltaTime,Space.World);
            foreach (var bounders in bounderVector)
            {
                bounders.transform.position += new Vector3(0f, 0f, Variables.fowardsSpeed * Time.deltaTime);
            }
        }
        
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(_firstFinger);
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
               if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(_firstFinger).fingerId))
               {
                   Variables.firstTouch = 1;
                   Variables.GameCondition = Variables.GC_Started;    
               }
                break;
           case Conditions.CT_MOVED:
               if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(_firstFinger).fingerId))
               {
                   _rigidbody.velocity = new Vector3(_touch.deltaPosition.x * Speed * Time.fixedDeltaTime,
                       transform.position.y,
                       _touch.deltaPosition.y * Speed * Time.fixedDeltaTime);   
               }

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

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            PlayerRespawner playerRespawner = new PlayerRespawner();
            playerRespawner.isPlayerCrash = true;
            CameraShackVar.CameraShackCall();
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            foreach (var furture in Furtures)
            {
                furture.GetComponent<SphereCollider>().enabled = true;
                furture.GetComponent<Rigidbody>().isKinematic = false;
            }
            if(workOnce == false)
            {
                if(_rewardedAds != null)
                {
            _rewardedAds.LoadRewardedAd();
                        workOnce = true;
                }
            }
            StartCoroutine(UIManagerVar.Fade());
            StartCoroutine(StopGame());
        }
    }

    private IEnumerator StopGame()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.2f);
        Variables.GameCondition = Variables.GC_ENDED;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }

    public void RestartPlayerSettings()
    {
        Variables.firstTouch = 0;
        workOnce = false;
        gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        foreach (var furture in Furtures)
        {
            furture.gameObject.transform.position = new Vector3(0, 0, 0);
            furture.GetComponent<SphereCollider>().enabled = false;
            furture.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
}