using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private bool _isActive = true;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive == false)
            {
                _isActive = true;
                StartCoroutine(Count(_delay));
            }
            else
            {
                StopCoroutine(Count(_delay));
                _isActive = false;
            }
        }
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int step = int.Parse(_text.text);

        while (_isActive)
        {
            step++;
            _text.text = step.ToString();
            yield return wait;
        }
    }
}