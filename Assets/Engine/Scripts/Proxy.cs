using UnityEngine;
using System.Collections;

namespace Engine {
	public class Proxy : MonoBehaviour {

		public GameObject PersistentPrefab;
		public string DefaultScene = "Menu";

		private static GameObject currentPersistent;
		public GameObject current {
			get {
				if (currentPersistent==null)
					initPersistent();
				return currentPersistent;
			}
		}

		void initPersistent() {
			currentPersistent = GameObject.FindWithTag ("Persistent");
			if (currentPersistent == null) {
				currentPersistent = (GameObject)Instantiate(PersistentPrefab);
				currentPersistent.name = PersistentPrefab.name;
				DontDestroyOnLoad(currentPersistent);
				Application.LoadLevel(DefaultScene);
			}
		}
		// Use this for initialization
		void Start () {
			currentPersistent = null;
			initPersistent ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}

