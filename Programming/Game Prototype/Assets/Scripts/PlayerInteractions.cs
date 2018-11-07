using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    [SerializeField]
    private GameObject _planeController;
    private PlaneNavigation _planeNavigation;
    private PlaneMovement _planeMovement;
    [SerializeField]
    private GameObject _gameManager;
    private GameManager _gameManagerScript;

    [SerializeField]
    private GameObject _spawnManager;
    private SpawnManager _spawnManagerScript;

    [SerializeField]
    private AkEvent platformSound;

    // Use this for initialization
    void Start ()
    {
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
        _planeMovement = _planeController.GetComponent<PlaneMovement>();
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _spawnManagerScript = _spawnManager.GetComponent<SpawnManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private void OnTriggerStay2D(Collider2D other)

    {
        if (other.name == "Portal")
        {
            _gameManagerScript.Victory();
        }

        if (other.name == "GreenGooParent")
        {
            _spawnManagerScript.PlayerDamage(5);
        }

        if (other.name == "YellowGooParent")
        {
            _spawnManagerScript.PlayerDamage(2);
        }

        if (Input.GetButtonDown("Interact") && other.name == "Lever")
        {
            _planeMovement.leverPulled = true;
            _planeNavigation._playerFrozen = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)

    {
        if (_planeNavigation._playerFrozen == false)
        {
            //switch to correct layer based on portal name
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Interact pressed");
                if (other.gameObject.tag == "Platform Portal")
                {
                    if (other.gameObject.name == "Platform 1 Portal 1" && _planeNavigation._currentPlane == 1)
                    {
                        ToPlane2(other);
                    }

                    if (other.gameObject.name == "Platform 1 Portal 2" && _planeNavigation._currentPlane == 1)
                    {
                        ToPlane3(other);
                    }

                    else if (other.gameObject.name == "Platform 2 Portal 1" && _planeNavigation._currentPlane == 1)
                    {
                        ToPlane2(other);
                    }

                    else if (other.gameObject.name == "Platform 3 Portal 1" && _planeNavigation._currentPlane == 1)
                    {
                        ToPlane3(other);
                    }

                    else if (other.gameObject.name == "Platform 1 Portal 1" && _planeNavigation._currentPlane == 2)
                    {
                        ToPlane1(other);
                    }

                    else if (other.gameObject.name == "Platform 2 Portal 1" && _planeNavigation._currentPlane == 2)
                    {
                        ToPlane1(other);
                    }

                    else if (other.gameObject.name == "Platform 2 Portal 2" && _planeNavigation._currentPlane == 2)
                    {
                        ToPlane3(other);
                    }

                    else if (other.gameObject.name == "Platform 3 Portal 2" && _planeNavigation._currentPlane == 2)
                    {
                        ToPlane3(other);
                    }

                    else if (other.gameObject.name == "Platform 1 Portal 2" && _planeNavigation._currentPlane == 3)
                    {
                        ToPlane1(other);
                    }

                    else if (other.gameObject.name == "Platform 2 Portal 2" && _planeNavigation._currentPlane == 3)
                    {
                        ToPlane2(other);
                    }

                    else if (other.gameObject.name == "Platform 3 Portal 1" && _planeNavigation._currentPlane == 3)
                    {
                        ToPlane1(other);
                    }

                    else if (other.gameObject.name == "Platform 3 Portal 2" && _planeNavigation._currentPlane == 3)
                    {
                        ToPlane2(other);
                    }
                }

                if (other.gameObject.tag == "Lever")
                {
                    _planeMovement.leverPulled = true;
                }
            }
        }

    }

    private void ToPlane1(Collision2D other)
    {
        StartCoroutine(_planeNavigation.Plane1Delay(other));

        //Play platform sound
        if (platformSound != null)
        {
            platformSound.HandleEvent(gameObject);
            Debug.Log("Triggering Platform sound");
        }
        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Aztec");

        other.gameObject.layer = 10;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color (255,255,0,255);

        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);

        }

        if (other.transform.childCount > 1)
        {
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);
        }
        _planeMovement.portal1Entered = true;
    }

    private void ToPlane2(Collision2D other)
    {
        StartCoroutine(_planeNavigation.Plane2Delay(other));

        //Play platform sound
        if (platformSound != null)
        {
            platformSound.HandleEvent(gameObject);
            Debug.Log("Triggering Platform sound");
        }

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Egyptian");

        other.gameObject.layer = 11;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[1];

        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[1];
        }

        if (other.transform.childCount > 1)
        {
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[1];
        }

        _planeMovement.portal2Entered = true;
    }

    private void ToPlane3(Collision2D other)
    {
        StartCoroutine(_planeNavigation.Plane3Delay(other));

        //Play platform sound
        if (platformSound != null)
        {
            platformSound.HandleEvent(gameObject);
            Debug.Log("Triggering Platform sound");
        }

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Chinese");

        other.gameObject.layer = 12;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[2];

        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[2];
        }

        if (other.transform.childCount > 1)
        {
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[2];
        }

        _planeMovement.portal3Entered = true;
    }

}
