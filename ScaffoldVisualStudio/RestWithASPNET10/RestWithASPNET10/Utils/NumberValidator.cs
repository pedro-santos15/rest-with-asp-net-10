namespace RestWithASPNET10.Utils
{
    public class NumberValidator
    {
        public bool IsNumeric(string strNumber)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue);

            //Globalização do valor ocorrendo, basicamente de qualquer lugar do mundo o usuário poderá settar o valor com a cada decimal do país
            //US 10.5 e BR 10,5
            return isNumber;
        }
    }
}
