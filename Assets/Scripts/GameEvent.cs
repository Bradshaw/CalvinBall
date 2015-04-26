using UnityEngine;
using System.Collections;

public class GameEvent : MonoBehaviour {

    public delegate void PassAction(PlayerCharacter from, PlayerCharacter to);
    public static event PassAction OnPass;

    public delegate void ShootAction(PlayerCharacter shooter);
    public static event ShootAction OnShoot;

    public delegate void InterceptAction(PlayerCharacter newPossessor, PlayerCharacter lastPossessor);
    public static event InterceptAction OnIntercept;

    public delegate void TackleAction(PlayerCharacter tackler, PlayerCharacter victim);
    public static event TackleAction OnTackle;

    public delegate void GoalAction(PlayerCharacter lastPossessor, Team goalPosts);
    public static event GoalAction OnGoal;

    public delegate void BallZoneAction(Collider2D zone);
    public static event BallZoneAction OnBallZoneEnter;
    public static event BallZoneAction OnBallZoneExit;
    public static event BallZoneAction OnBallZoneStay;

    public delegate void PlayerZoneAction(Collider2D zone, PlayerCharacter player);
    public static event PlayerZoneAction OnPlayerZoneEnter;
    public static event PlayerZoneAction OnPlayerZoneExit;
    public static event PlayerZoneAction OnPlayerZoneStay;



}
