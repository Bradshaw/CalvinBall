using UnityEngine;
using System.Collections;

public enum Team
{
    NONE,
    RED,
    BLUE
}

public class PlayerCharacter : MonoBehaviour {

    public Team team = Team.NONE;

}
