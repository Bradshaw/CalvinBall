using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(BallGrabber))]
	[RequireComponent(typeof(SimpleMovement))]
	public class BallKicker : MonoBehaviour {
		
		BallGrabber grabber;
		SimpleMovement move;

		[Tooltip("The Force applied to the Ball When kicking")]
		public float KickForce;
		[Tooltip("The amount of Time before grabbing balls again")]
		public float GrabCooldown;

		// Use this for initialization
		void Start () {
			grabber = GetComponent<BallGrabber> ();
			move = GetComponent<SimpleMovement>();
		}
		
		// Update is called once per frame
		void Update () {
		}

		public void Kick() {
			Debug.Log ("Kick");
			if (grabber.HasBall)  {
				grabber.nextGrabPossible = Time.time + GrabCooldown;
				Debug.Log ("isOwner");
				grabber.LooseBall ();
				Debug.Log ("lost ball");
				grabber.ball.position = transform.position + new Vector3(move.Forward.x, move.Forward.y, 0);
				grabber.ball.GetComponent<Rigidbody2D>().AddForce(move.Forward * KickForce);
			}
		}
	}
}
