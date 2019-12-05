using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject keycard;
    bool spaceHelmetOn;
    Objectives objectives;


    // Start is called before the first frame update
    void Start()
    {
        objectives = GameObject.Find("OVRPlayerController").GetComponent<Objectives>();
    }


    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == keycard && objectives.ObjectiveNumber == 7)
        {
            OVR
            SceneManager.LoadScene("TitleScene");
        }
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
            SetMaterialAlpha();
            yield return new WaitForEndOfFrame();
        }
    }

}
