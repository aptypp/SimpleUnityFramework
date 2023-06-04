using UnityEngine;

namespace Tools.FileSaves
{
    public class Encryption
    {
        private const short _KEY_LENGTH = 1000;
        private const string _KEY_NAME = "3ncr1pt10nk3y";
        private const string _ALPHABET = "1234567890_-+=[];',.qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private readonly string _key;

        public Encryption()
        {
            if (PlayerPrefs.HasKey(_KEY_NAME))
            {
                _key = PlayerPrefs.GetString(_KEY_NAME);
                return;
            }

            _key = GetRandomKey();
            PlayerPrefs.SetString(_KEY_NAME, _key);
        }

        public string Encrypt(string input) => Xor(input);

        public string Decrypt(string input) => Xor(input);

        private string Xor(string input)
        {
            char[] inputChars = input.ToCharArray();

            for (int index = 0; index < input.Length; index++)
            {
                inputChars[index] ^= _key[index % _key.Length];
            }

            return new string(inputChars);
        }

        private string GetRandomKey()
        {
            string key = string.Empty;

            for (int index = 0; index < _KEY_LENGTH; index++)
            {
                key += _ALPHABET[Random.Range(0, _ALPHABET.Length)];
            }

            return key;
        }
    }
}