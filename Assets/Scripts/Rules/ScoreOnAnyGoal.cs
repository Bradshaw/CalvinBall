using UnityEngine;
using System.Collections;

public class ScoreOnAnyGoal : MonoBehaviour {

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
        switch (kicker.team)
        {
            case Team.RED:
                //Give points to RED
                break;
            case Team.BLUE:
                //Give points to BLUE
                break;
        }
    }

}
