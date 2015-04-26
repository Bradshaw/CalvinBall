using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public Team side;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Ball")
        {
            var shooter = Movement.BallGrabber.BallOwner.GetComponent<PlayerCharacter>();
            if (shooter!=null)
                GameEvent.RaiseOnGoal(shooter, side);
        }
    }


}
