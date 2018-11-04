using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour {

    [SerializeField]
    private GameObject _planeController;
    private PlaneNavigation _planeNavigation;
    private PlaneMovement _planeMovement;

    // Use this for initialization
    void Start ()
    {
        _planeNavigation = _planeController.GetComponent<PlaneNavigation>();
        _planeMovement = _planeController.GetComponent<PlaneMovement>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private void OnTriggerStay2D(Collider2D other)

    {
        if (other.name == "End Game")
        {
            SceneManager.LoadScene(0);
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
