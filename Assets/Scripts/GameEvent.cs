using UnityEngine;
using System.Collections;

public class GameEvent : MonoBehaviour
{

    public delegate void PassAction(PlayerCharacter from, PlayerCharacter to);
    public static event PassAction OnPass;
    public static void RaiseOnPass(PlayerCharacter from, PlayerCharacter to)
    {
        if (OnPass != null)
            OnPass(from, to);
    }

    public delegate void ShootAction(PlayerCharacter shooter);
    public static event ShootAction OnShoot;
    public static void RaiseOnShoot(PlayerCharacter shooter)
    {
        if (OnShoot != null)
            OnShoot(shooter);
    }

    public delegate void InterceptAction(PlayerCharacter newPossessor, PlayerCharacter lastPossessor);
    public static event InterceptAction OnIntercept;
    public static void RaiseOnIntercept(PlayerCharacter newPossessor, PlayerCharacter lastPossessor)
    {
        if (OnIntercept != null)
            OnIntercept(newPossessor, lastPossessor);
    }

    public delegate void TackleAction(PlayerCharacter tackler, PlayerCharacter victim);
    public static event TackleAction OnTackle;
    public static void RaiseOnTackle(PlayerCharacter tackler, PlayerCharacter victim)
    {
        if (OnTackle != null)
            OnTackle(tackler, victim);
    }

    public delegate void GoalAction(PlayerCharacter lastPossessor, Team against);
    public static event GoalAction OnGoal;
    public static void RaiseOnPass(PlayerCharacter lastPossessor, Team against)
    {
        if (OnGoal != null)
            OnGoal(lastPossessor, against);
    }

    public delegate void BallZoneAction(Collider2D zone);
    public static event BallZoneAction OnBallZoneEnter;
    public static void RaiseOnBallZoneEnter(Collider2D zone)
    {
        if (OnBallZoneEnter != null)
            OnBallZoneEnter(zone);
    }
    public static event BallZoneAction OnBallZoneExit;
    public static void RaiseOnBallZoneExit(Collider2D zone)
    {
        if (OnBallZoneExit != null)
            OnBallZoneExit(zone);
    }
    public static event BallZoneAction OnBallZoneStay;
    public static void RaiseOnBallZoneStay(Collider2D zone)
    {
        if (OnBallZoneStay != null)
            OnBallZoneStay(zone);
    }

    public delegate void PlayerZoneAction(Collider2D zone, PlayerCharacter player);
    public static event PlayerZoneAction OnPlayerZoneEnter;
    public static void RaiseOnPlayerZoneEnter(Collider2D zone, PlayerCharacter player)
    {
        if (OnPlayerZoneEnter != null)
            OnPlayerZoneEnter(zone, player);
    }
    public static event PlayerZoneAction OnPlayerZoneExit;
    public static void RaiseOnPlayerZoneExit(Collider2D zone, PlayerCharacter player)
    {
        if (OnPlayerZoneExit != null)
            OnPlayerZoneExit(zone, player);
    }
    public static event PlayerZoneAction OnPlayerZoneStay;
    public static void RaiseOnPlayerZoneStay(Collider2D zone, PlayerCharacter player)
    {
        if (OnPlayerZoneStay != null)
            OnPlayerZoneStay(zone, player);
    }



}

