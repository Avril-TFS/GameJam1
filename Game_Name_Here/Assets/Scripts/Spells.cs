using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public enum Spell
    {
        Angry,
        Disgust,
        Fear,
        Happy,
        Sad,
        Surprise,
        Neutral
    }

    public Spell currentEmotion;

    public PlayerController playerController;

    public Light flashlight;
    public bool flashlightOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CastSpell(Spell spell)
    {
        currentEmotion = spell;

        //  playerController.SpellBuffs();

        switch (spell)
        {
            case Spell.Angry:
                CastAngrySpell();
                break;
        }
        switch (spell)
        {
            case Spell.Disgust:
                CastDisgustSpell();
                break;
        }
        switch (spell)
        {
            case Spell.Fear:
                CastFearSpell();
                break;
        }
        switch (spell)
        {
            case Spell.Happy:
                CastHappySpell();
                break;
        }
        switch (spell)
        {
            case Spell.Sad:
                CastSadSpell();
                break;
        }
        switch (spell)
        {
            case Spell.Surprise:
                CastSurpriseSpell();
                break;
        }
        switch (spell)
        {
            case Spell.Neutral:
                // We dont have a spell for this, also in neutral an emotion?
                break;
        }
    }

    void CastAngrySpell()
    {
        // FIRE!
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
