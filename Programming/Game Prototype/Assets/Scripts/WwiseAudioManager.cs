using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseAudioManager : MonoBehaviour {

    [SerializeField]
    public AkEvent playerJump;
    [SerializeField]
    public AkEvent playerLand;
    [SerializeField]
    public AkEvent playerDeath;
    [SerializeField]
    public AkEvent enemyCharge;
    [SerializeField]
    public AkEvent enemyDeath;
    [SerializeField]
    public AkEvent platformProgress;
    [SerializeField]
    public AkEvent dialogueIn;
    [SerializeField]
    public AkEvent planeRotate;
    [SerializeField]
    public AkEvent platformMove;

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

}
