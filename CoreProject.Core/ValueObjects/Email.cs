using System.Text.RegularExpressions;

namespace CoreProject.Core.ValueObjects
{
    public class Email
    {
        //Informação adquirida do manual do Manual_de_Orientacao_Contribuinte_v_6.00

        public const int MaxLength = 60;

        public string Value { get; private set; }

        public Email(string value)
        {
            Value = value?.Trim();
        }

        public bool IsValid()
        {
            //https://regex101.com/r/mX1xW0/1
            if (Value == null) return false;
            if (string.IsNullOrEmpty(Value)) return true;
            if (Value.Length > MaxLength) return false;

            var regexEmail = new Regex(@"^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$");
            return regexEmail.IsMatch(Value);
        }
    }
}
