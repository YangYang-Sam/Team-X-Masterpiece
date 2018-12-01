using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject audioManager;
    private WwiseAudioManager wwiseAudioManager;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject _player;
    private PlayerController2D _playerController2D;
    [SerializeField]
    private GameObject[] _spawnPoint;
    [SerializeField]
    private float _spawnTime;

    // Use this for initialization
    void Start ()
    {
        _playerController2D = _player.GetComponent<PlayerController2D>();

        wwiseAudioManager = audioManager.GetComponent<WwiseAudioManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayerDamage(int SpawnPoint)
    {

        if (animator.GetBool("IsDying") == false)
        {
            wwiseAudioManager.PlayerDeathSound();
        }

        animator.SetBool("IsDying", true);
        animator.SetBool("IsJumping", false);

        _playerController2D._playerFrozen = true;

        StartCoroutine(SpawnDelay(SpawnPoint));
    }

    public IEnumerator SpawnDelay(int SpawnPoint)
    {
        yield return new WaitForSeconds(_spawnTime);
        SpawnPlayer(SpawnPoint);
        animator.SetBool("IsDying", false);
        animator.SetBool("IsSpawning", true);

    }

    private void SpawnPlayer(int SpawnPoint)
    {
        if (SpawnPoint == 1)
        {
            Debug.Log("SpawnPoint 1");
            _player.gameObject.transform.position = _spawnPoint[0].transform.position;
        }
        else if (SpawnPoint == 2)
        {
            Debug.Log("SpawnPoint 2");
            _player.gameObject.transform.position = _spawnPoint[1].transform.position;
        }
        else if (SpawnPoint == 3)
        {
            Debug.Log("SpawnPoint 3");
            _player.gameObject.transform.position = _spawnPoint[2].transform.position;
        }
        else if (SpawnPoint == 4)
        {
            Debug.Log("SpawnPoint 4");
            _player.gameObject.transform.position = _spawnPoint[3].transform.position;
        }

        Debug.Log("Player spawned");
        _playerController2D._playerFrozen = false;
    }
}
