using System;

namespace DefaultNamespace
{
    public class RandomCharacter : ICharacter
    {
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
                // Generating a random number.
                var rand = _random.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                char letter = Convert.ToChar(rand + 97);

                _value = letter.ToString();
            }

            return _value;
        }
    }
}