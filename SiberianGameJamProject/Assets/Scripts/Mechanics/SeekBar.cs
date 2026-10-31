using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;
using UnityEngine.Video;

public class SeekBar : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] public SplineContainer _seekBarSpline;
    [SerializeField] public GameObject _daysAnim;
    [SerializeField] public GameObject[] _daysAnimClips;
    private int _currentAnim;
    private float _currentFrame = 0f;
    float p = 0f;
    float videoSpacing = 1f / 4;
    private float _cadrVideo;
    private float _frameDuration;
    private bool _isPlaying = false;
    private Coroutine _playCoroutine;
    private float _totalFrame;


    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_animators[i] != null && _animators[i].runtimeAnimatorController != null)
            {
                _animators[i].speed = 0; // Пауза по умолчанию для ВСЕХ аниматоров
            }
        }
    }

    public void WindowPwOpen()
    {
     
        _daysAnim.SetActive(true);
    }
    public void OppanPlayer(int indexday)
    {
        if (_isPlaying)
        {
            _isPlaying = false;
            if (_playCoroutine != null)
            {
                StopCoroutine(_playCoroutine);
                _playCoroutine = null;
            }
        }

        // Сбрасываем и скрываем все клипы и ставим их на паузу
        for (int i = 0; i < 3; i++)
        {
            _daysAnimClips[i].SetActive(false);
            if (_animators[i] != null) _animators[i].speed = 0;
        }

        p = 0;
        _currentFrame = 0;
        _daysAnimClips[indexday].SetActive(true);
        _daysAnim.SetActive(false);

        // <-- КРИТИЧЕСКИ ВАЖНО: Обновляем индекс текущего аниматора!
        _currentAnim = indexday;

        InitializeAnimation(indexday);
    }
    private void InitializeAnimation(int index)
    {
        if (_animators[index] == null || _animators[index].runtimeAnimatorController == null) return;

        var clip = _animators[index].runtimeAnimatorController.animationClips[0];
        _frameDuration = 1f / clip.frameRate;
        _animators[index].speed = 0; // Пауза по умолчанию
        _totalFrame = clip.frameRate * clip.length;
        _cadrVideo = clip.frameRate*clip.length;
        Debug.Log(_frameDuration);
        Debug.Log(clip.frameRate);
    }
    private void ApplyFrame()
    {
        var clip = _animators[_currentAnim].runtimeAnimatorController.animationClips[0];
        _currentFrame = Mathf.Clamp(_currentFrame, 0f, clip.length);
        float normalizedTime = _currentFrame / clip.length;
        _animators[_currentAnim].Play(clip.name, 0, normalizedTime);
    }

    public void SeekRotatiom()
    {
       
    }
    public void OnA(InputAction.CallbackContext ctntx)
    {
        if (ctntx.performed)
        {
            _currentFrame -= _frameDuration*2;
            ApplyFrame();
            UpdateSeekPosition(0);
         
        }
    }
    public void OnD(InputAction.CallbackContext ctntx)
    {
        if (ctntx.performed)
        {
            _currentFrame += _frameDuration*2;
            ApplyFrame();
            UpdateSeekPosition(2);
            
        }
    }
    public void UpdateSeekPosition(int ad)
    {


       
        if (ad > 1)
        {
            p += 1f/_totalFrame;
         
        }
        if (ad < 1)
        {
            p -= 1f/_totalFrame;
         
        }
        p = Mathf.Clamp01(p);
        Vector3 pos = _seekBarSpline.EvaluatePosition(p);
        transform.position = new Vector3(pos.x, 190, 0f);
    }
    public void ButtonsPlay()
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            _playCoroutine = StartCoroutine(PlaySequence());
        }
        else if (_playCoroutine != null)
        {
            StopCoroutine(_playCoroutine);
        }
    }


    private IEnumerator PlaySequence()
    { 
        if(p==1f)
        { p = 0f;
            _currentFrame = 0;
            ApplyFrame();
        }
       
        for (int i = 0; i < _totalFrame; i++)
        {
            _currentFrame += _frameDuration;
            ApplyFrame();
            UpdateSeekPosition(2);
          
            yield return new WaitForSeconds(0.05f); 
        }
        
    }

}
