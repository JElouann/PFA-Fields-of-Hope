using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimePostProcessHandler : MonoBehaviour
{
    private Coroutine _currentProcess;
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
    [SerializeField] public Coroutine _specialProcess;

    [Header("On night fall")]
    [SerializeField] private AnimationCurve _vignetteNightFallCurve;

    [Header("On day rise")]
    [SerializeField] private AnimationCurve _vignetteDayRiseCurve;

    [Header("Black panels")]
    [SerializeField] private NightPanel _topBlackPanel;
    [SerializeField] private NightPanel _bottomBlackPanel;

    private void Awake()
    {
        _volume = Camera.main.transform.GetChild(0).GetComponent<Volume>();
        _volume.profile.TryGet(out _vignette);
        _baseColor = _vignette.color.value;
    }

    public void StartOpe()
    {
        StopAllCoroutines();
        StopCoroutine(BasisProcess());
        StartCoroutine(NightFall());
    }

    #region OnNightFall
    public IEnumerator NightFall()
    {
        _time = 0;
        
        while (_time <= _vignetteNightFallCurve.length / 4)
        {
            _vignette.intensity.value = _vignetteNightFallCurve.Evaluate(_time);
            _time += _vignetteNightFallCurve.length * 0.0001f;
            _vignette.color.value = Color.Lerp(_vignette.color.value, Color.black, _vignetteNightFallCurve.length * 0.0001f);           
            yield return new WaitForSeconds(_vignetteNightFallCurve.length * 0.0001f);
            if(_time >= 0.8f && !NightPanel.IsNight)
            {
                NightPanel.IsNight = true;
                _topBlackPanel.Move(270);
                _bottomBlackPanel.Move(-270);
            }
        }
        yield return new WaitForSeconds(1.5f);
        _specialProcess = StartCoroutine(DayRise());
    }
    #endregion

    #region OnDayRise
    public IEnumerator DayRise()
    {
        _time = 0;
        _vignette.intensity.value = 1;
        while (_time <= _vignetteDayRiseCurve.length / 4.5f)
        {
            _vignette.intensity.value = _vignetteDayRiseCurve.Evaluate(_time);
            _time += _vignetteDayRiseCurve.length * 0.0001f;
            _vignette.color.value = Color.Lerp(Color.black, _baseColor, _vignetteDayRiseCurve.length * 0.0001f);
            yield return new WaitForSeconds(_vignetteDayRiseCurve.length * 0.0001f);
            if (_time <= 0.2f && NightPanel.IsNight)
            {
                NightPanel.IsNight = false;
                _topBlackPanel.Move(810);
                _bottomBlackPanel.Move(-810);
            }
        }
        _specialProcess = null;
        StartCoroutine(BasisProcess());
    }
    #endregion

    public IEnumerator BasisProcess()
    {
        _time = 0;
        while (_specialProcess == null)
        {
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

    public void AGNEUGNEUGNA()
    {
        StartCoroutine(BasisProcess());
    }
}
