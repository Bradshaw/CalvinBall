﻿using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(PlayerCharacter))]
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(BallGrabber))]
	public class SimpleMovement : MonoBehaviour {

		Rigidbody2D rigid;
		BallGrabber grabber;
		AIControlled aiControl;
		UserControlled userControl;

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
		[Tooltip("RotationSpeed for the Character")]
		public float rotateSpeed = 2;

		
		[Header("Debug")]
		public UnityEngine.UI.Text debugOut;


		GameObject[] ownTeam {
			get  {
				return grabber.ownTeam;
			}
		}
		
		public bool hasBall {
			get  {
				return grabber.hasBall;
			}
			set  {
				grabber.hasBall = hasBall;
			}
		}

		public bool teamHasBall {
			get  {
				return grabber.teamHasBall;
			}
		}

		Vector2 currentGoal;
		GameObject ball;

		public void RunTowards(Transform goal)  {
			RunTowards (goal.position);
		}
		
		public void RunTowards(Vector3 goal)  {
			var distance = goal - transform.position;
			RunTowards (new Vector2 (distance.x, distance.y));
		}

		public void RunTowards(Vector2 goal)  {
			currentGoal = goal;
		}

		public void PlayerControl()  {
			aiControl.LooseControl();
			userControl.GetControl();
		}
		public void AIControl()  {
			aiControl.GetControl();
			userControl.LooseControl();
		}


		public void TakeControl()  {
			foreach (var Player in ownTeam)
				if (Player.gameObject != gameObject && Player.GetComponent<SimpleMovement> ()!= null)
					Player.GetComponent<SimpleMovement> ().AIControl ();
			PlayerControl ();
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
			grabber = GetComponent<BallGrabber> ();
			rigid = GetComponent<Rigidbody2D>();
			aiControl = GetComponent<AIControlled>();
			userControl = GetComponent<UserControlled>();
			aiControl.GetControl ();
		}
		
		// Update is called once per frame
		void Update () {
		}

		void RotateTowards(Vector2 goal)  {
			if (goal.magnitude>0.2f) {
				transform.right = Vector3.RotateTowards (transform.right, new Vector3(goal.x, goal.y,0),rotateSpeed,rotateSpeed);
				if (transform.localEulerAngles.y == 180)
					transform.localEulerAngles = new Vector3 (0, 0, 180);
			}

		}

		/*void //Debug (string text)  {
			if (debugOut!= null)
				debugOut.text += text;
		}*/

		void FixedUpdate () {
			if (debugOut!= null)
				debugOut.text = "";
			//adapt values to if we have ball
			float currentAcceleration = acceleration;
			if (hasBall)
				currentAcceleration -= accelerationBallMalus; 
			float currentMaxSpeed = maxSpeed;
			if (hasBall)
				currentMaxSpeed -= maxSpeedBallMalus; 
			//Debug ("\nAcceleration: " + currentAcceleration.ToString ());
			//Debug ("\nMaxSpeed: " + currentMaxSpeed.ToString ());
			//Debug ("\nCurrentSpeed: " +  rigid.velocity.magnitude.ToString ());

			//on ice, still not max speed
			if (onIce && rigid.velocity.magnitude < currentMaxSpeed) {

				//Debug ("\nON ICE");
				//Debug ("\nMovementEfficency: " +  MovementEfficency(currentGoal).ToString ());
				//Debug ("\nAdding Force: " +  (currentGoal * MovementEfficency(currentGoal) * currentAcceleration).ToString ());
				rigid.AddForce (currentGoal * MovementEfficency(currentGoal) * currentAcceleration);
			}

			//Rotation
			if (onIce) {
				RotateTowards(currentGoal);
			} else  {
				//we're on solid ground, so perfect transfere of speed when rotating

				float speed = rigid.velocity.magnitude;
				rigid.velocity = Vector2.zero;
				RotateTowards(currentGoal);
				rigid.velocity = Forward * speed; 
				//RotateTowards(currentGoal);
			} 

			//on solid ground, still not max speed
			if (onSolidGround && rigid.velocity.magnitude < currentMaxSpeed) {
				//Debug ( "\nON SOLID GROUND");
				//Debug ("\nAdding Force: " +  (currentGoal * currentAcceleration).ToString ());

				rigid.AddForce (currentGoal * currentAcceleration);
			}
			//Debug ("\nCurrentSpeed after Updates: " +  rigid.velocity.magnitude.ToString ());
		}
	}

	public interface IMovementController {
		void GetControl();
		void LooseControl();
		bool HasControl();
	}

}
