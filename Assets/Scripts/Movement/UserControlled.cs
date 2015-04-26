using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(PlayerCharacter))]
	[RequireComponent(typeof(SimpleMovement))]
	[RequireComponent(typeof(BallKicker))]
	public class UserControlled : MonoBehaviour, IMovementController {

		public enum Player {
			Player1,
			Player2
		}


		SimpleMovement move;
		PlayerCharacter playerC;
		BallKicker ballKicker;
		bool currentControl;

		Player player;
		
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
			move = GetComponent<SimpleMovement>();
			playerC = GetComponent<PlayerCharacter>();
			ballKicker = GetComponent<BallKicker>();
			player = Player.Player1;
			if (playerC.team == Team.RED)
				player = Player.Player2;
		}
		
		// Update is called once per frame
		void Update () {
			var h = Input.GetAxis ("Horizontal" + player.ToString());
			var v = Input.GetAxis ("Vertical" + player.ToString());

			if (HasControl()){
				move.RunTowards(new Vector2(h, v));
				if (Input.GetButton ("Kick" + player.ToString()))
					ballKicker.Kick();
			}
		}
	}
}
