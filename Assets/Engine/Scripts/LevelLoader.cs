using UnityEngine;
using System.Collections;

namespace Engine {
	[RequireComponent(typeof(Proxy))]
	public class LevelLoader : MonoBehaviour {

		private Proxy proxy;

		public void LoadLevel(string Name) {
			Application.LoadLevel(Name);
		}

		public void LoadDefault() {
			LoadLevel (proxy.DefaultScene);
		}

		public void Back()  {
			if (proxy.DefaultScene == Application.loadedLevelName) {
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
			} else  {
				LoadDefault();
			}
		}

		void Start() {
			proxy = GetComponent<Proxy>();
		}

		void Update() {
			if (Input.GetButton("Cancel") ){
				Back ();
			}
		}

	}
}
