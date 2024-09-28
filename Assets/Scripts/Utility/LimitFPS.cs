using UnityEngine;

public class LimitFPS : MonoBehaviour
{
	public int fps = 16;

	void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = fps;
	}

	void Update()
	{
		
	}
}