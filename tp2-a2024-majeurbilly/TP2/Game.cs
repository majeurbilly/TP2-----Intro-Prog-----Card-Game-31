using System;

namespace TP2
{
    public class Game
    {
        #region Constants

        public const int HEART = 0;
        public const int DIAMOND = 1;
        public const int SPADE = 2;
        public const int CLUB = 3;

        public const int ACE = 0;
        public const int TWO = 1;
        public const int THREE = 2;
        public const int FOUR = 3;
        public const int FIVE = 4;
        public const int SIX = 5;
        public const int SEVEN = 6;
        public const int EIGHT = 7;
        public const int NINE = 8;
        public const int TEN = 9;
        public const int JACK = 10;
        public const int QUEEN = 11;
        public const int KING = 12;

        public static int[] FACES = { JACK, QUEEN, KING };

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int CARDS_VALUE_PER_INDEX = 13;
        public const int NUM_CARDS_IN_HAND = 3;

        public const int FACES_SCORE = 10;
        public const int ACES_SCORE = 11;

        public const int MAX_SCORE = 31;
        public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
        public const int ALL_FACES_SCORE = 30;
        public const int ONLY_FACES_SCORE = 28;
        public const int SAME_COLOR_SEQUENCE_SCORE = 28;
        public const int SEQUENCE_SCORE = 26;
        public const int SAME_COLOR_SCORE = 24;

        #endregion

        public static int GetSuitFromCardIndex(int index)
        {
            return index / NUM_CARDS_PER_SUIT;
        }

        public static int GetValueFromCardIndex(int index)
        {
            return index % CARDS_VALUE_PER_INDEX;
        }


        public static int GetScoreFromCardValue(int cardValue)
        {
            if (cardValue == ACE)
            {
                return ACES_SCORE;
            }
            else if (FACES.Contains(cardValue))
            {
                return FACES_SCORE;
            }
            else
            {
                return GetValueFromCardIndex(cardValue) + 1;
            }
        }

        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }


        public static int GetHighestCardValue(int[] cardsValues)
        {
            int highestValue = 0;
            for (int i = 0; i < cardsValues.Length; i++)
            {
                int cardValue = cardsValues[i];
                if (cardValue == ACE)
                {
                    return cardValue;
                }

                else if (cardValue > highestValue)
                {
                    highestValue = cardValue;
                }
            }

            return highestValue;
        }

        public static bool HasOnlySameColorCards(int[] colorValues)
        {
            bool isRed = false;
            bool isBlack = false;

            for (int i = 0; i < colorValues.Length; i++)
            {
                int[] redCard = { HEART, DIAMOND };

                if (colorValues[i] > CLUB)
                {
                    return false;
                }

                {
                }
                if (redCard.Contains(colorValues[i]))
                {
                    isRed = true;
                }
                else
                {
                    isBlack = true;
                }
            }

            if (isRed && isBlack)
            {
                return false;
            }

            return true;
        }

        public static bool HasAllSameCardValues(int[] cardValues)
        {
            for (int i = 1; i < cardValues.Length - 1; i++)
            {
                if (cardValues[i] != cardValues[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasAllFaces(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (HasOnlyFaces(values) && HasSequence(values))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasOnlyFaces(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (!FACES.Contains(GetValueFromCardIndex(values[i])))
                {
                    return false;
                }
            }

            return true;
        }
        

        public static bool HasSameColorSequence(int[] values, int[] colors)
        {
            int[] arrayEnOrdre = GetCardInOrder(values);

            if ((!HasOnlySameColorCards(colors)) || !HasSequence(arrayEnOrdre))
            {
                return false;
            }

            return true;
        }

        public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
        {
            int temp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (suits[i] == suit)
                {
                    temp += GetScoreFromCardValue(values[i]);
                }
            }

            return temp;
        }

        private static int[] GetCardInOrder(int[] values)
        {
            bool permutation = true;
            while (permutation)
            {
                permutation = false;
                for (int i = 0; i < values.Length - 1; i++)
                {
                    int temp = 0;
                    if (values[i] > values[i + 1])
                    {
                        temp += values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = temp;
                        permutation = true;
                    }
                }
            }

            return values;
        }

        public static bool HasSequence(int[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                int[] arrayOrder = GetCardInOrder(values);
                if (arrayOrder[i] + 1 != arrayOrder[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            int[] colorsValues = new int[cardIndexes.Length];
            int[] cardValues = new int[cardIndexes.Length];
            for (int i = 0; i < cardIndexes.Length; i++)
            {
                colorsValues[i] = GetSuitFromCardIndex(cardIndexes[i]);
                cardValues[i] = GetValueFromCardIndex(cardIndexes[i]);
            }
            return new int[] { GetHandScoreWithSpecialCombinasion(cardValues, colorsValues), GetHighestCardValue(cardValues), GetHighestColorScore(colorsValues, cardValues) }.Max();
        }

        private static int GetHighestColorScore(int[] colorsValues, int[] cardValues)
        {
            int bestSuitScore = 0;
            for (int i = 0; i < colorsValues.Length; i++)
            {
                int suitScore = GetScoreFromMultipleCardsOfASuit(colorsValues[i], cardValues, colorsValues);
                if (bestSuitScore < suitScore)
                {
                    bestSuitScore = suitScore;
                }
            }
            return bestSuitScore;
        }

        private static int GetHandScoreWithSpecialCombinasion(int[] cardValues, int[] colorsValues)
        {
            int handScoreWithSpecialCombinasion = 0;
            if (HasAllSameCardValues(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ALL_SAME_CARDS_VALUE_SCORE)
                {
                    handScoreWithSpecialCombinasion = ALL_SAME_CARDS_VALUE_SCORE;
                }
            }

            if (HasOnlyFaces(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ONLY_FACES_SCORE)
                {
                    handScoreWithSpecialCombinasion = ONLY_FACES_SCORE;
                }
            }

            if (HasOnlySameColorCards(colorsValues))
            {
                if (handScoreWithSpecialCombinasion < SAME_COLOR_SCORE)
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SCORE;
                }
            }

            if (HasSequence(cardValues))
            {
                if (handScoreWithSpecialCombinasion < SEQUENCE_SCORE)
                {
                    handScoreWithSpecialCombinasion = SEQUENCE_SCORE;
                }
            }

            if (HasSameColorSequence(cardValues, colorsValues))
            {
                if (handScoreWithSpecialCombinasion < SAME_COLOR_SEQUENCE_SCORE)
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SEQUENCE_SCORE;
                }
            }

            if (HasAllFaces(cardValues))
            {
                if (handScoreWithSpecialCombinasion < ALL_FACES_SCORE)
                {
                    handScoreWithSpecialCombinasion = ALL_FACES_SCORE;
                }
            }

            return handScoreWithSpecialCombinasion;
        }

        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCard;

                    do
                    {
                        newCard = new Random().Next(0, NUM_CARDS);
                    } while (!availableCards[newCard]);

                    availableCards[newCard] = true;
                    cardValues[i] = newCard;
                    availableCards[newCard] = false;
                }
            }
        }
    }
}