namespace RandomAlgos;

public class Algorithms {
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
}
