using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseAudioManager : MonoBehaviour {

    [SerializeField]
    private AkEvent playerJump;
    [SerializeField]
    private AkEvent playerLand;
    [SerializeField]
    private AkEvent playerDeath;
    [SerializeField]
    private AkEvent enemyCharge;
    [SerializeField]
    private AkEvent enemyDeath;
    [SerializeField]
    private AkEvent platformProgress;
    [SerializeField]
    private AkEvent dialogueIn;
    [SerializeField]
    private AkEvent planeRotate;
    [SerializeField]
    private AkEvent platformMove;
    [SerializeField]
    private AkEvent dialogueBleep;
    [SerializeField]
    private AkEvent enemyBoulder;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void JumpSound()
    {
        if (playerJump != null)
        {
            playerJump.HandleEvent(gameObject);
        }
    }

    public void PlayerDeathSound()
    {
        if (playerDeath != null)
        {
            playerDeath.HandleEvent(gameObject);
        }
    }

    public void EnemyChargeSound()
    {
        if (enemyCharge != null)
        {
            enemyCharge.HandleEvent(gameObject);
        }
    }

    public void EnemyDeathSound()
    {
        if (enemyDeath != null)
        {
            enemyDeath.HandleEvent(gameObject);
        }
    }

    public void PlatformSound()
    {
        if (platformMove != null)
        {
            platformMove.HandleEvent(gameObject);
        }
    }

    public void PlatformProgressSound()
    {
        if (platformProgress != null)
        {
            platformProgress.HandleEvent(gameObject);
        }
    }

    public void PlayerLandSound()
    {
        if (playerLand != null)
        {
            playerLand.HandleEvent(gameObject);
        }
    }

    public void DialogueInSound()
    {
        if (dialogueIn != null)
        {
            dialogueIn.HandleEvent(gameObject);
        }
    }

    public void PlaneRotateSound()
    {
        if (planeRotate != null)
        {
            planeRotate.HandleEvent(gameObject);
        }
    }

    public void DialogueBleepSound()
    {
        if (dialogueBleep != null)
        {
            dialogueBleep.HandleEvent(gameObject);
        }
    }

    public void EnemyBoulderSound()
    {
        if (enemyBoulder != null)
        {
            enemyBoulder.HandleEvent(gameObject);
        }
    }

}
