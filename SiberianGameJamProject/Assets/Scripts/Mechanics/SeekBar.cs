using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;
using UnityEngine.Video;

public class SeekBar : MonoBehaviour
{
    [SerializeField] public SplineContainer _seekBarSpline;
    [SerializeField] public VideoClip _videoZoo;
    float p = 0f;
    float videoSpacing = 1f / 4;
    public int _cadrVideo;

    public void SeekRotatiom()
    {
       
    }
    public void OnA(InputAction.CallbackContext ctntx)
    {
        if (ctntx.performed)
        {
            UpdateSeekPosition(0);
        }
    }
    public void OnD(InputAction.CallbackContext ctntx)
    {
        if (ctntx.performed)
        {
            UpdateSeekPosition(2);
        }
    }
    public void UpdateSeekPosition(int ad)
    {
    

    
        if (ad > 1)
        {
            p += videoSpacing;
        }
        if (ad < 1)
        {
            p -= videoSpacing;
        }
        p = Mathf.Clamp01(p);
        Vector3 pos = _seekBarSpline.EvaluatePosition(p);
        transform.position = new Vector3(pos.x, 190, 0f);
    }
    public void ButtonsPlay()
    {
      
        StartCoroutine(PlaySequence());
    }


    private IEnumerator PlaySequence()
    {
        p = -1f;
        for (int i = 0; i < _cadrVideo; i++)
        {
            UpdateSeekPosition(2);          
            yield return new WaitForSeconds(1f); 
        }
    }

}
