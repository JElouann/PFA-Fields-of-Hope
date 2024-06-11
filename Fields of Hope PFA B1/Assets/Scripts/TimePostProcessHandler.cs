using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimePostProcessHandler : MonoBehaviour
{
    private Coroutine currentProcess;
    private float _time;
    private Color _baseColor;

    // Volume Component
    private Volume _volume;

    // Overrides
    private Vignette _vignette;
    private Bloom _bloom;

    // Animation curves
    [Header("Basis Curve")]
    [SerializeField] private AnimationCurve _vignetteBasisCurve;
    [SerializeField] private Coroutine _specialProcess;

    [Header("On night fall")]
    [SerializeField] private AnimationCurve _vignetteNightFallCurve;
    [SerializeField] private NightPanel _topBlackPanel;
    [SerializeField] private NightPanel _bottomBlackPanel;

    private void Awake()
    {
        _volume = Camera.main.transform.GetChild(0).GetComponent<Volume>();
        _volume.profile.TryGet(out _vignette);
        _volume.profile.TryGet(out _bloom);
        _baseColor = _vignette.color.value;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_vignette.intensity.value = 1.00f;
        //currentProcess = StartCoroutine(BasisProcess());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            currentProcess = StartCoroutine(NightFall());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space");
            StopAllCoroutines();
            StartCoroutine(NightFall());
        }
    }

    #region OnNightFall
    public IEnumerator NightFall()
    {
        _time = 0;
        while (_time <= _vignetteNightFallCurve.length / 4)
        {
            print(_time);
            _vignette.intensity.value = _vignetteNightFallCurve.Evaluate(_time);
            _time += _vignetteNightFallCurve.length * 0.0001f;
            _vignette.color.value = Color.Lerp(_vignette.color.value, Color.black, _vignetteNightFallCurve.length * 0.0005f);           
            yield return new WaitForSeconds(_vignetteNightFallCurve.length * 0.0001f);
            if(_time >= 0.8f && !NightPanel.IsNight)
            {
                NightPanel.IsNight = true;
                _topBlackPanel.Move(270);
                _bottomBlackPanel.Move(-270);
            }
        }
    }
    #endregion

    public IEnumerator BasisProcess()
    {
        _time = 0;
        while (true)
        {
            if (_specialProcess != null) yield return null;
            _vignette.intensity.value = _vignetteBasisCurve.Evaluate(_time);
            if( _time == _vignetteBasisCurve.length )
            {
                _time = 0;
            }
            else
            {
                _time += _vignetteBasisCurve.length * 0.0125f;
            }
            yield return new WaitForSeconds(_vignetteBasisCurve.length * 0.0125f);
        }
    }
}
