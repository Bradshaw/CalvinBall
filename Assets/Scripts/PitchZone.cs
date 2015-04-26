using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class PitchZone : MonoBehaviour {

    Collider2D _col;

    public void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Ball":
                GameEvent.RaiseOnBallZoneEnter(_col);
                break;
            case "Player":
                GameEvent.RaiseOnPlayerZoneEnter(_col, col.GetComponent<PlayerCharacter>()); 
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {

    }

}
