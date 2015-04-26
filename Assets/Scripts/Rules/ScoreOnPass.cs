using UnityEngine;
using System.Collections;

public class ScoreOnPass : Rule {

    public override string ToString()
    {
        return "Score on pass";
    }

    void OnEnable()
    {
        GameEvent.OnPass += GivePoint;
    }


    void OnDisable()
    {
        GameEvent.OnPass -= GivePoint;
    }

    void GivePoint(PlayerCharacter from, PlayerCharacter to)
    {
        Debug.Log(from.team);
        // TODO Give points to team
        switch (from.team)
        {
            case Team.BLUE:
                // Give a point to team BLUE
                break;
            case Team.RED:
                // Give a point to team RED
                break;
        }
    }
}
