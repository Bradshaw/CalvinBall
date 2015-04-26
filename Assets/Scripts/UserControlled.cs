using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(SimpleMovement))]
	public class UserControlled : MonoBehaviour, IMovementController {

		public enum Player {
			Player1,
			Player2
		}


		SimpleMovement move;
		bool currentControl;

		[Tooltip("Which player is this")]
		public Player player;
		
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
		}
		
		// Update is called once per frame
		void Update () {
			var h = Input.GetAxis ("Horizontal" + player.ToString());
			var v = Input.GetAxis ("Vertical" + player.ToString());

			if (HasControl()){
				move.RunTowards(new Vector2(h, v));
			}
		}
	}
}
