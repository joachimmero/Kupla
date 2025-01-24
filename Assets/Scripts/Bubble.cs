using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public bool Initialized { get; private set; }

    private ICharacter _character;

    public void Initialize(ICharacter character)
    {
        _character = character;
        Initialized = true;
    }

    private void Update()
    {
        if (!Initialized)
        {
            return;
        }

        BindText();
        HandleInput();
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
}
