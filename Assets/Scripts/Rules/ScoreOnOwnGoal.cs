using UnityEngine;
using System.Collections;

public class ScoreOnOwnGoal : MonoBehaviour {

    public override string ToString()
    {
        return "backstab|SCORE";
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
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().RedScore++;
                break;
            case Team.BLUE:
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().BlueScore++;
                break;
        }
    }

}
