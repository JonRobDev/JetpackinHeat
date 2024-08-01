using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class endingCode : MonoBehaviour
{
	public VideoPlayer vp;
	public long currentFrame;
	public ulong currFrame;
	public int nextScene;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(backup());
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentFrame = vp.frame;
		ulong currFrame = (ulong)currentFrame;
		if (currFrame == vp.frameCount - 3) 
		{
			SceneManager.LoadScene (nextScene);
			//Debug.Log("dead");
		}
	}

	public void GoToScene(){
		SceneManager.LoadScene (nextScene);
	}

	IEnumerator backup()
	{
		yield return new WaitForSeconds(8f);
		SceneManager.LoadScene(nextScene);
	}
}

