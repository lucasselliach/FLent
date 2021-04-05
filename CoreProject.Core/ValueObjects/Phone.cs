using System.Text.RegularExpressions;

namespace CoreProject.Core.ValueObjects
{
    public class Phone
    {
        //Informação adquirida do manual do Manual_de_Orientacao_Contribuinte_v_6.00

        public const int MinLength = 6;
        public const int MaxLength = 14;

        public string Value { get; private set; }

        public Phone(string value)
        {
            var valueTrim = value?.Trim();

            Value = valueTrim != null ? new Regex(@"[^\d]").Replace(valueTrim, "") : null;
        }

        public bool IsValid()
        {
            //https://regex101.com/r/lHbA3X/2
            if (Value == null) return false;
            if (string.IsNullOrEmpty(Value)) return true;
            if (Value.Length < MinLength) return false;
            if (Value.Length > MaxLength) return false;

            return new Regex(@"\(?(\b[0-9]{2,3}|0((x|[0-9]){2,3}[0-9]{2}))\)?\s*[0-9]{4,5}[- ]*[0-9]{4}\b").IsMatch(Value);
        }
    }
}
