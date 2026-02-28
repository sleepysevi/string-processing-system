namespace StringProcessingApp.Services
{
    public class StringService
    {
        // store original text 
        private string originalText = "";
        private string currentText = "";

        public void SetText(string text)
        {
            originalText = text;
            currentText = text;
        }

        public string GetCurrentText()
        {
            return currentText;
        }

        public bool HasText()
        {
            if (currentText == "")
                return false;
            return true;
        }

        // converts the text to uppercase using ToUpper()
        public string ToUpperCase()
        {
            currentText = currentText.ToUpper();
            return currentText;
        }

        // converts the text to lowercase using ToLower()
        public string ToLowerCase()
        {
            currentText = currentText.ToLower();
            return currentText;
        }

        // counts how many characters         public int CountCharacters()
        {
            int count = currentText.Length;
            return count;
        }

        // checks text if it contains a word using Contains()
        public bool ContainsWord(string word)
        {
            return currentText.Contains(word);
        }

        // replaces word in the text using Replace()
        public string ReplaceWord(string oldWord, string newWord)
        {
            currentText = currentText.Replace(oldWord, newWord);
            return currentText;
        }

        // gets a part of the text using Substring()
        public string ExtractSubstring(int startIndex, int length)
        {
            // validation
            if (startIndex < 0 || startIndex >= currentText.Length)
            {
                return "Error: start index is out of range.";
            }

            if (length <= 0 || startIndex + length > currentText.Length)
            {
                return "Error: length is invalid.";
            }

            string result = currentText.Substring(startIndex, length);
            return result;
        }

        // removes leading and trailing spaces using Trim()
        public string TrimSpaces()
        {
            currentText = currentText.Trim();
            return currentText;
        }

        // resets the text back to what the user originally entered
        public string ResetText()
        {
            currentText = originalText;
            return currentText;
        }
    }
}
