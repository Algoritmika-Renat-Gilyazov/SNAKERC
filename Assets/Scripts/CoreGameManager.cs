using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameManager: MonoBehaviour
	{
		AsyncOperation preloadOp;
		AsyncOperation preloadMainMenuOp;
		public static CoreGameManager Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Destroy(gameObject);
				return;
			}

			Instance = this;
			DontDestroyOnLoad(gameObject);
		}


		/*IEnumerator PreloadScene(string sceneName)
		{
			preloadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
			preloadOp.allowSceneActivation = false; // ← главный трюк
			float timeout = 10f;

			while (preloadOp.progress < 0.9f)
			{
				timeout -= Time.unscaledDeltaTime;
				if (timeout <= 0f)
				{
					Debug.LogError($"Предзагрузка сцены {sceneName} зависла!");
					yield break;
				}
				yield return null;
			}
			if (sceneName == "MainMenu")
			{
				preloadMainMenuOp = preloadOp;
			}

			Debug.Log("Сцена предзагружена, ждёт активации 👀");
		}

		public List<string> scenes = new List<string>();*/

		/*public IEnumerator Boot()
		{
			Debug.Log("CoreGameManager Booting...");

			foreach (var scene in scenes)
			{
				Debug.Log("Предзагрузка сцены: " + scene);
				yield return PreloadScene(scene);
			}

			// Если MainMenu была предзагружена — активируем её
			if (preloadMainMenuOp != null)
			{
				Debug.Log("Активация предзагруженной сцены MainMenu...");
				preloadMainMenuOp.allowSceneActivation = true;

				// Ждём полной активации сцены
				while (!preloadMainMenuOp.isDone)
				{
					yield return null;
				}

				// Установим MainMenu как активную сцену, если она валидна
				var menuScene = SceneManager.GetSceneByName("MainMenu");
				if (menuScene.IsValid())
				{
					SceneManager.SetActiveScene(menuScene);
					Debug.Log("MainMenu активирована и установлена как активная сцена.");
				}
				else
				{
					Debug.LogWarning("MainMenu активирована, но сцена не найдена через SceneManager.GetSceneByName.");
				}
			}
			else
			{
				Debug.LogWarning("MainMenu не была предзагружена — выполняю обычную загрузку.");
				SceneManager.LoadScene("MainMenu");
				// Можно дождаться конца кадра, чтобы дать Unity начать загрузку
				yield return null;
			}

			yield return new WaitForSeconds(5f);
			Debug.Log("CoreGameManager Booted.");
		}*/
	}