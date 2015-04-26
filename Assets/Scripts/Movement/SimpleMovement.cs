using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(Rigidbody2D))]
	public class SimpleMovement : MonoBehaviour {

		Rigidbody2D rigid;
		AIControlled aiControl;
		UserControlled userControl;
		
		[Header("Properties controlling behaviour")]
		[Tooltip("Determines if the Character has the Ball or not")]
		public bool HasBall;
		[Tooltip("Determines if the Player's team has the Ball or not")]
		public bool TeamHasBall;

		[Header("Randomized Values controlling the Character")]
		[Tooltip("Maximum Speed for the Character")]
		public float maxSpeed;
		[Tooltip("Slowdown when having the Ball")]
		public float maxSpeedBallMalus;
		[Tooltip("Acceleration for the Character")]
		public float acceleration;
		[Tooltip("Dimished acceleration when having the Ball")]
		public float accelerationBallMalus;
		[Tooltip("If the character is on solid ground he can do sharp turns, if not he's on ice and thus skits along")]
		public bool onSolidGround;
		public bool onIce {
			get  {
				return !onSolidGround;
			}
			set  {
				onSolidGround = !value;
			}
		}
		
		[Header("Debug")]
		public UnityEngine.UI.Text debugOut;

		Vector2 currentGoal;

		public void RunTowards(Transform goal)  {
			RunTowards (goal.position);
		}
		
		public void RunTowards(Vector3 goal)  {
			RunTowards (new Vector2(goal.x, goal.y));
		}

		public void RunTowards(Vector2 goal)  {
			currentGoal = goal;
		}

		public Vector2 Forward {
			get  {
				var temp = new Vector2(transform.right.x, transform.right.y);
				temp.Normalize();
				return temp;
			}
		}
		float AngleToDirection(Vector2 goal) {
			return Vector2.Angle (Forward, goal);
		}
		
		float AngleEfficency(float Angle) {
			if (Angle == 0)
				return 1;
			if (Angle < 180) {
				return 1 - (Angle/180);
			}
			return ((Angle-180)/180);
		}

		float MovementEfficency(Vector2 goal)  {
			return AngleEfficency(AngleToDirection(goal));
		}

		// Use this for initialization
		void Start () {
			rigid = GetComponent<Rigidbody2D>();
			aiControl = GetComponent<AIControlled>();
			userControl = GetComponent<UserControlled>();
			aiControl.GetControl ();
		}
		
		// Update is called once per frame
		void Update () {
			if (HasBall && aiControl.HasControl()) {
				aiControl.LooseControl();
				userControl.GetControl();
			}
		}

		void RotateTowards(Vector2 goal)  {
			
		}

		void FixedUpdate () {
			debugOut.text = "";
			//adapt values to if we have ball
			float currentAcceleration = acceleration;
			if (HasBall)
				currentAcceleration -= accelerationBallMalus; 
			float currentMaxSpeed = maxSpeed;
			if (HasBall)
				currentMaxSpeed -= maxSpeedBallMalus; 
			debugOut.text += "\nAcceleration: " + currentAcceleration.ToString ();
			debugOut.text += "\nMaxSpeed: " + currentMaxSpeed.ToString ();
			debugOut.text += "\nCurrentSpeed: " +  rigid.velocity.magnitude.ToString ();

			//on ice, still not max speed
			if (onIce && rigid.velocity.magnitude < currentMaxSpeed) {
				debugOut.text += "\nON ICE";
				debugOut.text += "\nMovementEfficency: " +  MovementEfficency(currentGoal).ToString ();
				debugOut.text += "\nAdding Force: " +  (currentGoal * MovementEfficency(currentGoal) * currentAcceleration).ToString ();
				rigid.AddForce (currentGoal * MovementEfficency(currentGoal) * currentAcceleration);
			}

			//Rotation
			if (onIce) {
				RotateTowards(currentGoal);
			} else  {
				//we're on solid ground, so perfect transfere of speed when rotating
				/*
				 * removed because meaybe it's better without?
				float speed = rigid.velocity.magnitude;
				rigid.velocity = Vector2.zero;
				RotateTowards(currentGoal);
				rigid.velocity = Forward * speed; */
				RotateTowards(currentGoal);
			} 

			//on solid ground, still not max speed
			if (onSolidGround && rigid.velocity.magnitude < currentMaxSpeed) {
				debugOut.text += "\nON SOLID GROUND";
				debugOut.text += "\nAdding Force: " +  (currentGoal * currentAcceleration).ToString ();

				rigid.AddForce (currentGoal * currentAcceleration);
			}
			debugOut.text += "\nCurrentSpeed after Updates: " +  rigid.velocity.magnitude.ToString ();
		}
	}

	public interface IMovementController {
		void GetControl();
		void LooseControl();
		bool HasControl();
	}

}
