using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPk : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator[] _animators;
    [SerializeField] private GameObject _loaderObj;
    [SerializeField] private GameObject _groupAnimationObj;
    [SerializeField] private GameObject _groupAnimationObjFolder;
    [SerializeField] private GameObject _buttonOff;
    private float _totalFrame;
    private float _currentFrame = 0f;
    float p = 0f;
    private float _frameDuration;
    public void Start()
    {
        _groupAnimationObjFolder.SetActive(false);
        _groupAnimationObj.SetActive(false);
        _loaderObj.SetActive(false);
        InitializeAnimation();
    }
    private void InitializeAnimation()
    {
       
        var clip = _animators[0].runtimeAnimatorController.animationClips[0];
        _animators[0].speed = 0; // Пауза по умолчанию
        _totalFrame = clip.frameRate * clip.length;
        _frameDuration = 1f / clip.frameRate;


        Debug.Log(clip.frameRate);
    }
    private void ApplyFrame()
    {
        var clip = _animators[0].runtimeAnimatorController.animationClips[0];
        _currentFrame = Mathf.Clamp(_currentFrame, 0f, clip.length);
        float normalizedTime = _currentFrame / clip.length;
        _animators[0].Play(clip.name, 0, normalizedTime);
    }
    public void ButtonsPlay()
    {

        _loaderObj.SetActive(true);
        StartCoroutine(PlaySequence());
        
      
    }
    private IEnumerator PlaySequence()
    {
        if (_currentFrame >= _totalFrame)
        {
            _currentFrame = 0;
            ApplyFrame();
        }
        int totalFramesInt = Mathf.CeilToInt(_totalFrame);
        for (int i = 0; i < _totalFrame; i++)
        {
            _currentFrame += _frameDuration;
            ApplyFrame();
            yield return new WaitForSeconds(0.05f);
        }
        _buttonOff.SetActive(false);
        _loaderObj.SetActive(false);
        _groupAnimationObj.SetActive(true);
        _groupAnimationObjFolder.SetActive(true);
        

    }
}
