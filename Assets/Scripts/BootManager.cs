using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BootManager: MonoBehaviour
{
	//public CoreGameManager core = CoreGameManager.Instance;
	public bool booted = false;

	// Use this for initialization
	void Start()
	{
		//core.StartCoroutine(core.Boot());
		StartCoroutine(Loader());
	}
		
	private IEnumerator Loader()
	{
		yield return new WaitForSeconds(2);
		booted = true;
		SceneManager.LoadScene("MainMenu");
	}

	// Update is called once per frame
	void Update()
	{
		if (!booted)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
			else if (Input.GetKeyDown(KeyCode.F8))
			{
				SceneManager.LoadScene("SetupEnv0");
			}
		}
	}
}