using System;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public event Action Escaped;
    public bool Initialized { get; private set; }

    private ICharacter _character;
    private BubbleBounds _bubbleBounds;
    private Vector2 _force;

    public void Initialize(ICharacter character, BubbleBounds bubbleBounds)
    {
        _character = character;
        _bubbleBounds = bubbleBounds;

        Initialized = true;
    }

    public void AddForce(Vector2 force)
    {
        _force = force;
    }

    private void Update()
    {
        if (!Initialized)
        {
            return;
        }

        BindText();
        HandleInput();
        Fly();
        HandleBounds();
    }

    private void BindText()
    {
        if (text.text == _character.Value())
        {
            return;
        }

        text.text = _character.Value();
    }

    private void HandleInput()
    {
        if(Input.inputString.Contains(_character.Value()))
        {
            Destroy(gameObject);
        }
    }

    private void Fly()
    {
        transform.Translate(_force * Time.deltaTime);
    }

    private void HandleBounds()
    {
        if (!_bubbleBounds.InsideBounds(this))
        {
            Escaped?.Invoke();
            Destroy(gameObject);
        }
    }
}
