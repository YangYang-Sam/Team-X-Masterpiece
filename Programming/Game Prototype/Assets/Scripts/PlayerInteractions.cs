using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    ////////TEMP DIALOGUE FIX////////////
    [SerializeField]
    private GameObject _dialogueBox;

    [SerializeField]
    private GameObject _planeController;
    private PlayerController2D _playerController2D;
    private PlaneNavigation _planeNavigation;
    private PlaneMovement _planeMovement;
    [SerializeField]
    private GameObject _gameManager;
    private GameManager _gameManagerScript;

    [SerializeField]
    private GameObject _spawnManager;
    private SpawnManager _spawnManagerScript;

    [SerializeField]
    private GameObject _dialogueManager;
    private DialogueManager _dialogueManagerScript;

    [SerializeField]
    private AkEvent platformSound;

    // Use this for initialization
    void Start ()
    {
        _playerController2D = GetComponent<PlayerController2D>();
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
        _planeMovement = _planeController.GetComponent<PlaneMovement>();
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _spawnManagerScript = _spawnManager.GetComponent<SpawnManager>();
        _dialogueManagerScript = _dialogueManager.GetComponent<DialogueManager>();

        AkSoundEngine.SetState("Music_State", "Aztec");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private void OnTriggerStay2D(Collider2D other)

    {
        if (Input.GetButtonDown("Interact") && _playerController2D._playerFrozen == false && _dialogueManagerScript.dialogFreezePlayer == false && _playerController2D.isGrounded)
        {
            //switch to correct layer based on portal name
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
        }

        if (Input.GetButtonDown("Interact") && other.name == "Lever")
        {
            //Disable collider so lever can only be pulled once
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            _planeMovement.leverPulled = true;
            _playerController2D._playerFrozen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)

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

    }

    private void ToPlane1(Collider2D other)
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

    private void ToPlane2(Collider2D other)
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

    private void ToPlane3(Collider2D other)
    {
        StartCoroutine(_planeNavigation.Plane3Delay(other));

        //Play platform sound
        if (platformSound != null)
        {
            platformSound.HandleEvent(gameObject);
            Debug.Log("Triggering Platform sound");
        }

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Eastern");

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
