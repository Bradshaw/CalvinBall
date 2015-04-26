using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(PlayerCharacter))]
	[RequireComponent(typeof(SimpleMovement))]
	public class BallGrabber : MonoBehaviour {
		
		SimpleMovement move;
		PlayerCharacter playerC;

		public GameObject[] ownTeam;
		public bool HasBall;
		public bool TeamHasBall;

		public static Team BallTeam;
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
			set  {
				//onSolidGround = !value;
			}
		}
		
		
		public void GetBall()  {
			HasBall = true;
			//TakeControl ();
		}
		
		
		public void LooseBall()  {
			HasBall = true;
		}


		// Use this for initialization
		void Start () {
			move = GetComponent<SimpleMovement>();
			playerC = GetComponent<PlayerCharacter>();
			ownTeam = GameObject.FindGameObjectsWithTag ("Character");
			BallTeam = Team.NONE;
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}