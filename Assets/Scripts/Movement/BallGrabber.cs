﻿using UnityEngine;
using System.Collections;
using System.Linq;

namespace Movement {
	[RequireComponent(typeof(PlayerCharacter))]
	[RequireComponent(typeof(SimpleMovement))]
	public class BallGrabber : MonoBehaviour {

		public Transform ball;
		float ballRadius;
		float characterRadius;
		public float nextGrabPossible;

		SimpleMovement move;
		PlayerCharacter playerC;

		public GameObject[] ownTeam;
		public bool HasBall;
		public bool TeamHasBall;

		public static Team BallTeam;
		public static GameObject BallOwner;
		public bool hasBall {
			get  {
				return HasBall;
			}
			set  {
				if (!HasBall && value)
					GetBall();
				if (HasBall && !value)
					LooseBall();
			}
		}
		
		public bool teamHasBall {
			get  {
				return TeamHasBall;
			}
		}
		
		
		public void GetBall()  {
			if (Time.time > nextGrabPossible)  {
				Debug.Log("Ball Grabbed");
				HasBall = true;
				TeamHasBall = true;
				BallTeam = playerC.team;
				/*ball.parent = transform;
				ball.localPosition = new Vector3 (ballRadius+characterRadius, 0, 0);*/
				move.TakeControl ();
				BallOwner = gameObject;
			}
		}
		
		
		public void LooseBall()  {
			//ball.parent = null;
			HasBall = false;
		}


		// Use this for initialization
		void Start () {
			nextGrabPossible = Time.time;
			move = GetComponent<SimpleMovement>();
			playerC = GetComponent<PlayerCharacter>();
			var tempOwnTeam = GameObject.FindGameObjectsWithTag ("Character");
			var tempBall = GameObject.FindGameObjectsWithTag ("Ball");
			ownTeam = GameObject.FindGameObjectsWithTag ("Character").Where (q => q.GetComponent<PlayerCharacter>() != null).ToArray();
			ball = tempBall.Where(q => q.transform.parent == null).FirstOrDefault().transform;
			ballRadius = ball.GetComponentInChildren<CircleCollider2D> ().radius;
			characterRadius = GetComponentInChildren<CircleCollider2D> ().radius;
			BallTeam = Team.NONE;
			TeamHasBall = false;
		}
		
		// Update is called once per frame
		void Update () {
			if ((ball.position - transform.position).magnitude < (ballRadius + characterRadius)) {
				if (ball.transform.parent == null){
					GetBall ();
				} 
			} 

			if (BallTeam == playerC.team)
				TeamHasBall = true;

			if (HasBall)
				ball.position = transform.position + new Vector3(move.Forward.x, move.Forward.y, 0)* (ballRadius + characterRadius );
		}
	}
}