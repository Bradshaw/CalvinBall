using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(Rigidbody2D))]
	public class SimpleMovement : MonoBehaviour {

		Rigidbody2D rigid;
		AIControlled aiControl;
		UserControlled userControl;
		
		[Header("Properties controlling behaviour")]
		[Tooltip("Determines if the player has the Ball or not")]
		public bool HasBall;

		[Header("Randomized Values controlling the Character")]
		[Tooltip("Maximum Speed for the Character")]
		public float maxSpeed;
		[Tooltip("Slowdown when having the Ball")]
		public float maxSpeedBallMalus;
		[Tooltip("Acceleration for the Caracter")]
		public float acceleration;
		[Tooltip("Dimished acceleration when having the Ball")]
		public float accelerationBallMalus;
		[Tooltip("If the character is on solid ground he can do sharp turns, if not he's on ice and thus skis along")]
		public bool solidGround;
		public bool onIce {
			get  {
				return !solidGround;
			}
			set  {
				solidGround = !value;
			}
		}

		public void RunTowards(Vector2 goal)  {
			RunTowards (goal, 1);
		}
		
		public void RunTowards(Vector2 goal, float speed)  {
		}


		// Use this for initialization
		void Start () {
			rigid = GetComponent<Rigidbody2D>();
			aiControl = GetComponent<AIControlled>();
			userControl = GetComponent<UserControlled>();
		}
		
		// Update is called once per frame
		void Update () {
			if (HasBall && aiControl.HasControl()) {
				aiControl.LooseControl();
				userControl.GetControl();
			}
		}
	}

	public interface IMovementController {
		void GetControl();
		void LooseControl();
		bool HasControl();
	}

}
