using System;

namespace DefaultNamespace
{
    public class RandomCharacter : ICharacter
    {
        private string[] _characters = new[]
        {
            "a",
            "b",
            "c",
            "d"
        };

        private readonly Random _random;

        private string _value;

        public RandomCharacter()
        {
            _random = new Random();
        }

        public string Value()
        {
            if (_value == null)
            {
                _value = _characters[_random.Next(0, _characters.Length)];
            }

            return _value;
        }
    }
}