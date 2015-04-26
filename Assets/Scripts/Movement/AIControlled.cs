using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(PlayerCharacter))]
	[RequireComponent(typeof(SimpleMovement))]
	[RequireComponent(typeof(BallGrabber))]
	public class AIControlled : MonoBehaviour, IMovementController {
		
		SimpleMovement move;
		BallGrabber grabber;
		bool currentControl;

		Transform ball;
		[Tooltip("The degree of direction change when team doesn't have ball")]
		[Range(0,1)]
		public float randomness = 0.5f;

		public void GetControl()  {
			currentControl = true;
		}
		
		public void LooseControl()  {
			currentControl = false;
		}

		public bool HasControl()  {
			return currentControl;
		}

		// Use this for initialization
		void Start () {
			ball = GameObject.FindGameObjectWithTag ("Ball").transform;
			grabber = GetComponent<BallGrabber>();
		}

		// Update is called once per frame
		void Update () {
			move = GetComponent<SimpleMovement>();
			if (HasControl()){
				if (grabber.teamHasBall) {
					//not ocmpeltely random as we bascially would not move.. just randomly in the general direction we were already running
					move.RunTowards(
							Vector2.Lerp(
								move.Forward,
								new Vector2(Random.Range(-1,1), Random.Range(-1,1)),
								1-randomness
							)
						);
				} else  {
					move.RunTowards(ball);
				} 
			}
		}
	}
}