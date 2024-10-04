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
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CastSpell("Neutra;");
        }
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

            case "Neutral":
                // We dont have a spell for this, also in neutral an emotion?
                break;
        }
    }
    void CastAngrySpell()
    {
        // FIRE!
        Debug.Log("Cast Fire");
    }
    void CastDisgustSpell()
    {
        // Knockback
    }
    void CastFearSpell()
    {
        //move slower now, might implement slowed movement here might implement it in player controller
    }
    void CastHappySpell()
    {
        //health
        // Flashlight, I think I want to do on the player controller script
    }
    void CastSadSpell()
    {
        // splish splash
    }
    void CastSurpriseSpell()
    {
        // Speed boost, again not sure if I want it here or in player Controller
    }
    //void CastNeutralSpell(){} does this exist?
}
