using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
    public string LevelName;

    public virtual void GoToLevel()
    {
        LevelManager.Instance.GotoLevel(LevelName);
    }

    public virtual void RestartLevel()
    {
        GameManager.Instance.UnPause();
       Application.LoadLevel(Application.loadedLevel);
    }
	
}
