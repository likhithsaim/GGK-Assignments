using System;
class Methods
{
    //  Differentiating positive & negative values and processing them according to the combinations
    public string CategorizeInputs(string value1, string value2)
    {
        string addedBinary = "";
        if (value1[0] != '-' && value2[0] != '-')
        {
            string binary1 = ToBinary(value1);
            string binary2 = ToBinary(value2);
            addedBinary = BinaryAddition(binary1, binary2);
        }
        else if ((value1[0] == '-') && (value2[0] == '-'))
        {
            string binary1 = ToBinary(value1.Substring(1, value1.Length - 1));
            string binary2 = ToBinary(value2.Substring(1, value2.Length - 1));
            addedBinary = BinaryAddition(binary1, binary2);
        }
        else if ((value1[0] == '-') && (value2[0] != '-'))
        {
            string binary1 = ToBinary(value1.Substring(1, value1.Length - 1));
            string binary2 = ToBinary(value2);
            string twosComplementOf1 = TwosComplement(binary1);
            addedBinary = BinaryAddition(twosComplementOf1, binary2);
        }
        else if ((value1[0] != '-') && (value2[0] == '-'))
        {
            string binary1 = ToBinary(value1);
            string binary2 = ToBinary(value2.Substring(1, value2.Length - 1));
            string twosComplementOf2 = TwosComplement(binary2);
            addedBinary = BinaryAddition(twosComplementOf2, binary1);
        }
        return ToDecimal(addedBinary);
    }
    //  Converting number to binary format
    string ToBinary(string numberString)
    {
        string[] splitString = numberString.Split('.');
        long integral = Int64.Parse(splitString[0]);
        float mantessa;
        if (splitString.Length == 1)
            mantessa = 0.0f;
        else
            mantessa = float.Parse("0." + splitString[1]);
        string binary = "";
        long z = 0, i = 1;
        while (integral != 0)
        {
            z = z + (integral % 2) * i;
            integral /= 2;
            i *= 10;
        }
        binary = binary + z.ToString() + ".";
        z = 64;
        long addingIntegral;
        while (z > 0)
        {
            mantessa *= 2;
            string str2 = Convert.ToString(mantessa);
            string[] splitString2 = str2.Split('.');
            addingIntegral = Int64.Parse(splitString2[0]);
            binary = binary + addingIntegral.ToString();
            if (splitString2.Length == 1)
            {
                mantessa = 0.0f;
            }
            else
            {
                mantessa = float.Parse("0." + splitString2[1]);
            }
            z--;
        }
        return binary;
    }
    //  Converting binary value to decimal
    string ToDecimal(string binary)
    {
        int index = binary.IndexOf('.');
        int length = binary.Length;
        int i = index - 1, j = index + 1, varies = 1;
        double sums = 0, increments;
        while (i >= 0)
        {
            sums += (binary[i--] - 48) * varies;
            varies *= 2;
        }
        increments = 0.5;
        while (j < length)
        {
            if (binary[j++] == '1')
            {
                sums += increments;
            }
            increments *= 0.5;
        }
        return sums.ToString();
    }
    //Finding Two's complement
    string TwosComplement(string binary)
    {
        string paddedString = "";
        int i = 0;
        int index = binary.IndexOf('.');
        int j = 0;
        while (j < 64 - index)
        {
            paddedString += "0";
            j++;
        }
        string onesComplement = "";
        paddedString = paddedString + binary;
        while (i < paddedString.Length)
        {
            if (paddedString[i] == '.')
            {
                onesComplement += paddedString[i];
            }
            else
            {
                onesComplement += (paddedString[i] == '1') ? '0' : '1';
            }
            i++;
        }
        string z = BinaryAddition(onesComplement, "0.".PadRight(65, '0') + "1");
        return z;
    }
    //  Adding binary values
    string BinaryAddition(string binary1, string binary2)
    {
        int length1 = binary1.Length;
        int length2 = binary2.Length;
        int carry = 0;
        if (length1 > length2)
        {
            int length = length1 - length2;
            int i = 0;
            while (i < length)
            {
                binary2 = "0" + binary2;
                i++;
            }
        }
        else if (length1 < length2)
        {
            int length = length2 - length1;
            int i = 0;
            while (i < length)
            {
                binary1 = "0" + binary1;
                i++;
            }
        }
        binary1 = "0" + binary1;
        binary2 = "0" + binary2;
        string additionString = "";
        int finalLength = binary1.Length - 1;
        while (finalLength >= 0)
        {
            if (binary1[finalLength] == '.')
            {
                additionString = "." + additionString;
            }
            else
            {
                int bitAddition = (Convert.ToInt32(binary1[finalLength]) - 48) + (Convert.ToInt32(binary2[finalLength]) - 48);
                if ((bitAddition == 2) && (carry == 1))
                {
                    additionString = "1" + additionString;
                    carry = 1;
                }
                else if ((bitAddition == 1 && carry == 1) || (bitAddition == 2 && carry == 0))
                {
                    additionString = "0" + additionString;
                    carry = 1;
                }
                else if ((bitAddition == 0 && carry == 1) || (bitAddition == 1 && carry == 0))
                {
                    additionString = "1" + additionString;
                    carry = 0;
                }
                else
                {
                    additionString = "0" + additionString;
                    carry = 0;
                }
            }
            finalLength--;
        }
        return additionString;
    }
}