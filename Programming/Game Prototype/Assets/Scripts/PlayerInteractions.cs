using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {


    [SerializeField]
    private GameObject audioManager;
    private WwiseAudioManager wwiseAudioManager;

    [SerializeField]
    private GameObject[] oneWayPlatforms;

    ////////TEMP DIALOGUE FIX////////////
    [SerializeField]
    private GameObject _dialogueBox1Control;
    [SerializeField]
    private GameObject _dialogueBox2Control;

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
    private GameObject[] outlines;

    [SerializeField]
    private GameObject leverObject;
    [SerializeField]
    private Sprite[] leverSprite;

    private bool Platform1Complete = false;
    private bool Platform2Complete = false;

    // Use this for initialization
    void Start ()
    {
        wwiseAudioManager = audioManager.GetComponent<WwiseAudioManager>();

        _playerController2D = GetComponent<PlayerController2D>();
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
        _planeMovement = _planeController.GetComponent<PlaneMovement>();
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _spawnManagerScript = _spawnManager.GetComponent<SpawnManager>();
        _dialogueManagerScript = _dialogueManager.GetComponent<DialogueManager>();

        leverObject.GetComponent<SpriteRenderer>().sprite = leverSprite[0];

        AkSoundEngine.SetState("Music_State", "Aztec");
        AkSoundEngine.SetState("Ambience_State", "AmbiAztec");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private void OnTriggerStay2D(Collider2D other)

    {
        if (_playerController2D._playerFrozen == false && _dialogueManagerScript.dialogFreezePlayer == false && _playerController2D.isGrounded)
        {
            //switch to correct layer based on portal name
            if (other.gameObject.tag == "Platform Portal")
            {

                if (other.gameObject.name == "Platform 1->2A" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane2(other);
                        oneWayPlatforms[0].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }
                    //Flash outline on correct plane
                    outlines[0].SetActive(true);

                    Debug.Log("Touching 1->2A");

                }

                else if (other.gameObject.name == "Platform 1->2B" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane2(other);
                    }

                    outlines[1].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 1->3A" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                    }

                    outlines[2].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 1->3B" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                    }

                    outlines[3].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 1->3C" && _planeNavigation._currentPlane == 1)
                {
                    _dialogueBox2Control.SetActive(true);
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                        oneWayPlatforms[1].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }

                    outlines[4].SetActive(true);

                }

                else if (other.gameObject.name == "Platform 2->1B" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane2(other);
                    }

                    outlines[6].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 3->1B" && _planeNavigation._currentPlane == 1)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                    }

                    outlines[8].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 2->1A" && _planeNavigation._currentPlane == 2)
                {
                    _dialogueBox1Control.SetActive(true);
                    if (Input.GetButtonDown("Interact"))
                    {
                        Platform1Complete = true;
                        ToPlane1(other);
                        oneWayPlatforms[6].GetComponent<Animator>().SetBool("FadeToGrey", true);
                        if (Platform1Complete == true)
                        {
                            wwiseAudioManager.PlatformProgressSound();
                        }
                        Platform1Complete = false;
                    }

                }

                else if (other.gameObject.name == "Platform 2->1B" && _planeNavigation._currentPlane == 2)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                    }
                }

                else if (other.gameObject.name == "Platform 2->3" && _planeNavigation._currentPlane == 2)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                        oneWayPlatforms[2].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }

                    outlines[5].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 1->2B" && _planeNavigation._currentPlane == 2)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                    }
                }

                else if (other.gameObject.name == "Platform 3->2B" && _planeNavigation._currentPlane == 2)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane3(other);
                    }

                    outlines[7].SetActive(true);
                }

                else if (other.gameObject.name == "Platform 3->1A" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        Platform2Complete = true;
                        ToPlane1(other);
                        if (Platform2Complete == true)
                        {
                            wwiseAudioManager.PlatformProgressSound();
                        }
                        Platform2Complete = false;
                        oneWayPlatforms[3].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }
                }

                else if (other.gameObject.name == "Platform 3->1B" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                    }
                }

                else if (other.gameObject.name == "Platform 3->1C" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                        oneWayPlatforms[4].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }
                }

                else if (other.gameObject.name == "Platform 3->2A" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane2(other);
                        oneWayPlatforms[5].GetComponent<Animator>().SetBool("FadeToGrey", true);
                    }
                }

                else if (other.gameObject.name == "Platform 3->2B" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane2(other);
                    }
                }

                else if (other.gameObject.name == "Platform 1->3A" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                    }
                }

                else if (other.gameObject.name == "Platform 1->3B" && _planeNavigation._currentPlane == 3)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        ToPlane1(other);
                    }
                }
            }
        }

        if (Input.GetButtonDown("Interact") && other.name == "Lever" && _playerController2D._playerFrozen == false)
        {
            //Disable collider so lever can only be pulled once
            //other.gameObject.GetComponent<Collider2D>().enabled = false;
            _planeMovement.leverPulled = true;
            _playerController2D._playerFrozen = true;
            wwiseAudioManager.PlaneRotateSound();

            if (leverObject.GetComponent<SpriteRenderer>().sprite == leverSprite[0])
            {
                leverObject.GetComponent<SpriteRenderer>().sprite = leverSprite[1];
            }
            else if(leverObject.GetComponent<SpriteRenderer>().sprite == leverSprite[1])
            {
                leverObject.GetComponent<SpriteRenderer>().sprite = leverSprite[0];
            }
        }

        if (other.name == "GreenGooAudioTrigger" && _planeNavigation._currentPlane == 1)
        {
            AkSoundEngine.SetState("Goo_Yes_No", "Near_Goo");
        }

        if (other.name == "YellowGooAudioTrigger" && _planeNavigation._currentPlane == 2)
        {
            AkSoundEngine.SetState("Goo_Yes_No", "Near_Goo");
        }

        if (other.name == "FlamesAudioTrigger" && _planeNavigation._currentPlane == 3)
        {
            AkSoundEngine.SetState("Fire_Yes_No", "Near_Fire");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach(GameObject gameobject in outlines)
        {
            gameobject.SetActive(false);
        }

        if (other.name == "GreenGooAudioTrigger" || other.name == "YellowGooAudioTrigger")
        {
            Debug.Log("Left goo area");
            AkSoundEngine.SetState("Goo_Yes_No", "No_Goo");
        }

        if (other.name == "FlamesAudioTrigger")
        {
            Debug.Log("Left flame area");
            AkSoundEngine.SetState("Fire_Yes_No", "No_Fire");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.name == "Portal")
        {
            _gameManagerScript.Victory();
            AkSoundEngine.SetState("Music_State", "EndLevel");
            AkSoundEngine.SetState("Ambience_State", "None");
        }

        if (other.name == "GreenGooParent")
        {
            _spawnManagerScript.PlayerDamage(4);
        }

        if (other.name == "YellowGooParent")
        {
            _spawnManagerScript.PlayerDamage(2);
        }

    }

    private void ToPlane1(Collider2D other)
    {
        StartCoroutine(_planeNavigation.Plane1Delay(other));

        wwiseAudioManager.PlatformSound();

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Aztec");
        AkSoundEngine.SetState("Ambience_State", "AmbiAztec");

        other.gameObject.layer = 10;

        if (other.transform.childCount == 0)
        {
            other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];
        }

        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];

        }

        if (other.transform.childCount > 1)
        {
            other.transform.GetChild(1).GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[0];
        }

        _planeMovement.portal1Entered = true;
    }

    private void ToPlane2(Collider2D other)
    {
        StartCoroutine(_planeNavigation.Plane2Delay(other));

        wwiseAudioManager.PlatformSound();

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Egyptian");
        AkSoundEngine.SetState("Ambience_State", "AmbiEgypt");

        other.gameObject.layer = 11;

        if (other.transform.childCount == 0)
        {
            other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[1];
        }

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

        wwiseAudioManager.PlatformSound();

        //Change audio to correct plane
        AkSoundEngine.SetState("Music_State", "Eastern");
        AkSoundEngine.SetState("Ambience_State", "AmbiEastern");

        other.gameObject.layer = 12;

        if (other.transform.childCount == 0)
        {
            other.gameObject.GetComponent<SpriteRenderer>().material = _planeMovement._planeMaterials[2];
        }

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
