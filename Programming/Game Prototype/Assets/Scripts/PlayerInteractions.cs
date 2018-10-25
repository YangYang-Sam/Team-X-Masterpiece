using System.Collections;
using System.Collections.Generic;
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
        //if (other.gameObject.tag == "Platform Portal")
        //{
        //    if (Input.GetButtonDown("Interact"))
        //    {
        //        if (other.gameObject.name == "Platform 1 Portal 1" && _planeNavigation._currentPlane == 1)
        //        {
        //            ToPlane2A(other);
        //        }

        //        if (other.gameObject.name == "Platform 1 Portal 2" && _planeNavigation._currentPlane == 1)
        //        {
        //            ToPlane3A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 1 Portal 1" && _planeNavigation._currentPlane == 2)
        //        {
        //            ToPlane1A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 1 Portal 2" && _planeNavigation._currentPlane == 3)
        //        {
        //            ToPlane1A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 2 Portal 1" && _planeNavigation._currentPlane == 1)
        //        {
        //            ToPlane2A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 2 Portal 1" && _planeNavigation._currentPlane == 2)
        //        {
        //            ToPlane1A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 2 Portal 2" && _planeNavigation._currentPlane == 3)
        //        {
        //            ToPlane2A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 3 Portal 1" && _planeNavigation._currentPlane == 1)
        //        {
        //            ToPlane3A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 2 Portal 2" && _planeNavigation._currentPlane == 2)
        //        {
        //            ToPlane3A(other);
        //        }

        //        else if (other.gameObject.name == "Platform 3 Portal 1" && _planeNavigation._currentPlane == 3)
        //        {
        //            ToPlane1A(other);
        //        }
        //    }

        //}

        if (Input.GetButtonDown("Interact") && other.name == "Lever")
        {
            _planeMovement.leverPulled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)

    {
        //switch to correct layer based on portal name
        if (Input.GetButtonDown("Interact"))
        {
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

    private void ToPlane1(Collision2D other)
    {
        other.gameObject.transform.parent = null;
        StartCoroutine(_planeNavigation.Plane1Delay());
        other.gameObject.layer = 10;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[0];
        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[0];
        }
        _planeMovement.portal1Entered = true;
    }

    private void ToPlane2(Collision2D other)
    {
        Debug.Log("Correct Function");
        other.gameObject.transform.parent = null;
        StartCoroutine(_planeNavigation.Plane2Delay());
        other.gameObject.layer = 11;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[1];
        if (other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[1];
        }
        _planeMovement.portal2Entered = true;
    }

    private void ToPlane3(Collision2D other)
    {
        other.gameObject.transform.parent = null;
        StartCoroutine(_planeNavigation.Plane3Delay());
        other.gameObject.layer = 12;
        other.gameObject.GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[2];
        if(other.transform.childCount > 0)
        {
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().material = _planeNavigation._planeMaterials[2];
        }
        _planeMovement.portal3Entered = true;
    }

    //private void ToPlane1A(Collider2D other)
    //{
    //    other.gameObject.transform.parent = null;
    //    StartCoroutine(_planeNavigation.Plane1Delay());
    //    other.gameObject.layer = 10;
    //    other.gameObject.transform.GetChild(0);
    //    _planeMovement.portal1Entered = true;
    //}

    //private void ToPlane2A(Collider2D other)
    //{
    //    other.gameObject.transform.parent = null;
    //    StartCoroutine(_planeNavigation.Plane2Delay());
    //    other.gameObject.layer = 11;
    //    other.gameObject.GetComponentInChildren<SpriteRenderer>().material = _planeNavigation._planeMaterials[1];
    //    _planeMovement.portal2Entered = true;
    //}

    //private void ToPlane3A(Collider2D other)
    //{
    //    other.gameObject.transform.parent = null;
    //    StartCoroutine(_planeNavigation.Plane3Delay());
    //    other.gameObject.layer = 12;
    //    other.gameObject.GetComponentInChildren<SpriteRenderer>().material = _planeNavigation._planeMaterials[2];
    //    _planeMovement.portal3Entered = true;
    //}

}
