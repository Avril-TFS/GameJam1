using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpells : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastSpell("Angry");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CastSpell("Disgust");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CastSpell("Fear");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CastSpell("Happy");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CastSpell("Sad");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CastSpell("Surprise");
        }
        // if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //   CastSpell("Neutral");
        //}
    }
    public void CastSpell(string spell)
    {
        switch (spell)
        {
            case "Angry":
                CastAngrySpell();
                break;

            case "Disgust":
                CastDisgustSpell();
                break;

            case "Fear":
                CastFearSpell();
                break;

            case "Happy":
                CastHappySpell();
                break;

            case "Sad":
                CastSadSpell();
                break;

            case "Surprise":
                CastSurpriseSpell();
                break;

                //  case "Neutral":
                // We dont have a spell for this, also is neutral an emotion?
                //   break;
        }
    }
    void CastAngrySpell()
    {
        // FIRE!
        Debug.Log("Cast Fire");
        playerController.BaseSpeed();
        playerController.FireBall();
    }
    void CastDisgustSpell()
    {
        // Knockback
        Debug.Log("Cast Disgust");
        playerController.BaseSpeed();
        playerController.KnockBack(10f, 25f);
    }
    void CastFearSpell()
    {
        //move slower and cause self damage
        Debug.Log("Cast Fear");
        playerController.SlowDown();
        playerController.Damage(5);
        playerController.FearSound();
    }
    void CastHappySpell()
    {
        //healing
        // Flashlight, I think I want to do on the player controller script
        Debug.Log("Cast Happy");
        playerController.BaseSpeed();
        playerController.Healing(5);
        playerController.HappySoud();
    }
    void CastSadSpell()
    {
        // splish splash
        // damage spell, and self slow
        Debug.Log("Cast Sad");
        playerController.SlowDown();
        playerController.Splash(5f, 20, .5f, 5f);  // radius, damage, slowAmount, and slow duration
    }
    void CastSurpriseSpell()
    {
        // Speed boost
        Debug.Log("Cast Surprise");
        playerController.SpeedUp();
        playerController.ExcitedSound();
    }
    //void CastNeutralSpell(){} does this exist?
}
