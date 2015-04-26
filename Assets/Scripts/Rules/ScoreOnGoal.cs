﻿using UnityEngine;
using System.Collections;

public class ScoreOnGoal : MonoBehaviour {

    public override string ToString()
    {
        return "Score on goal";
    }

    void OnEnable()
    {
        GameEvent.OnGoal += GivePoint;
    }
    void OnDisable()
    {
        GameEvent.OnGoal -= GivePoint;
    }

    void GivePoint(PlayerCharacter kicker, Team against)
    {
        switch (against)
        {
            case Team.RED:
                //Give points to BLUE
                break;
            case Team.BLUE:
                //Give points to RED
                break;
        }
    }

}