using UnityEngine;
using System.Collections;

public class ScoreOnAnyGoal : MonoBehaviour {

    public override string ToString()
    {
        return "bothways|SCORE";
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
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().RedScore++;
                break;
            case Team.BLUE:
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().BlueScore++;
                break;
        }
    }

}
