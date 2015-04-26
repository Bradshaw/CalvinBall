using UnityEngine;
using System.Collections;

namespace Movement {
	[RequireComponent(typeof(SimpleMovement))]
	public class UserControlled : MonoBehaviour, IMovementController {
		
		bool currentControl;
		
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
		
		}
		
		// Update is called once per frame
		void Update () {
			if (HasControl()){
				
			}
		}
	}
}
