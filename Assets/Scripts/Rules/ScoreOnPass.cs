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
        switch (from.team)
        {
            case Team.BLUE:
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().BlueScore++;
                break;
            case Team.RED:
                Engine.Proxy.currentPersistent.GetComponent<KeepScore>().RedScore++;
                break;
        }
    }
}
