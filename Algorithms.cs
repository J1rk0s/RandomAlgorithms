using System.Text;

namespace RandomAlgos;

public class Algorithms {
    private static long _seed = 0;

    public bool LuhnValidation(string cardNum) {
        List<char> cardSplit = new(cardNum);

        if (cardSplit.Count % 2 == 0) {
            cardSplit.Insert(0, '0');
        }

        for (int i = 1; i < cardSplit.Count; i += 2) {
            int num = (int)char.GetNumericValue(cardSplit[i]);
            num = num * 2;

            if (num < 10) {
                cardSplit[i] = (char)(num + '0');
                continue;
            }

            int normalized = 0;
            while (num > 0) {
                normalized += num % 10;
                num /= 10;
            }

            cardSplit[i] = (char)(normalized + '0');
        }

        int res = 0;
        for (int i = 0; i < cardSplit.Count; i++) {
            res += (int)char.GetNumericValue(cardSplit[i]);
        }

        return res % 10 == 0;
    }

    public static long XorShift(long seed) {
        if (seed < 0) {
            throw new ArgumentOutOfRangeException("Seed cannot be less or equal to zero!");
        }

        seed ^= (seed << 13);
        seed ^= (seed >> 8);
        seed ^= (seed << 22);

        long absSeed = Math.Abs(seed);
        _seed = seed;

        return absSeed;
    }

    public static string PascalCaseToSnakeCase(string str) {
        StringBuilder builder = new StringBuilder(str);

        for (int i = 0; i < builder.Length; i++) {
            if (char.IsUpper(builder[i]) && i != 0) {
                builder.Insert(i, "_");
                i += 2;
            }
        }

        return builder.ToString().ToLower();
    }
}
