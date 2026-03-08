using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SetupEnv
{
	public class SetupManager : MonoBehaviour
	{
		public void Quit()
		{
			#region QUIT
				#if UNITY_EDITOR
					UnityEditor.EditorApplication.isPlaying = false;
				#else
					Application.Quit();
				#endif
			#endregion
		}

		public void LoadSetupScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}