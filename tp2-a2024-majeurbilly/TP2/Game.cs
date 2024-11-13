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
            return index % 13;
        }

        public static void DistributeCard(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCard;

                    do
                    {
                        newCard = new Random().Next(0, 52);
                    } while (!availableCards[newCard]);

                    availableCards[newCard] = true;
                    cardValues[i] = newCard;
                    availableCards[newCard] = false;
                }
            }
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
            int temp = GetValueFromCardIndex(cardValues[0]);
            for (int i = 1; i < cardValues.Length; i++)
            {
                if (GetValueFromCardIndex(cardValues[i]) != temp)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasAllFaces(int[] values)
        {
            const int ALL_FACES_SUM = JACK + QUEEN + KING;
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (!HasOnlyFaces(values))
                {
                    return false;
                }
            }

            if (!HasSequence(values))
            {
                return false;
            }

            return true;
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

        public static int[] SwitchAceValues(int[] cardValues)
        {
            bool permutation = true;
            while (permutation)
            {
                permutation = false;
                for (int i = 0; i < cardValues.Length; i++)
                {
                    int additionArray;
                    if (cardValues[i] == ACE)
                    {
                        cardValues[i] = ACES_SCORE;
                        permutation = true;
                    }
                }
            }

            return cardValues;
        }

        public static bool HasSameColorSequence(int[] values, int[] colors)
        {
            int[] arrayEnOrdre = PutCardInOrder(values);

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

        public static int[] PutCardInOrder(int[] values)
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
                int[] arrayOrder = PutCardInOrder(values);
                if (arrayOrder[i] + 1 != arrayOrder[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            int handScoreWithSpecialCombinasion = 0;
            int handScoreWithAddtion = 0;
            int handScoreWithHighestCard = 0;
            int finalHandScore = 0;
            int[] colorsValues = new int[cardIndexes.Length];
            for (int i = 0; i < cardIndexes.Length; i++)
            {
                colorsValues[i] = GetSuitFromCardIndex(cardIndexes[i]);
            }

      
            if (HasAllSameCardValues(cardIndexes))
            {
                handScoreWithSpecialCombinasion = ALL_SAME_CARDS_VALUE_SCORE;
            }

            else if (HasOnlyFaces(cardIndexes))
            {
                handScoreWithSpecialCombinasion = ONLY_FACES_SCORE;
            }
            else if (HasOnlySameColorCards(colorsValues))
            {
                if (HasSameColorSequence(cardIndexes, colorsValues))
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SEQUENCE_SCORE;
                }
                else
                {
                    handScoreWithSpecialCombinasion = SAME_COLOR_SCORE;
                }
            }

            else if (HasSequence(cardIndexes))
            {
                handScoreWithSpecialCombinasion = SEQUENCE_SCORE;
            }

            else if (HasSameColorSequence(cardIndexes, colorsValues))
            {
                handScoreWithSpecialCombinasion = SAME_COLOR_SEQUENCE_SCORE;
            }

            else if (HasAllFaces(cardIndexes))
            {
                handScoreWithSpecialCombinasion = ALL_FACES_SCORE;
            }
            else if (HasOnlySameColorCards(colorsValues))
            {
                handScoreWithAddtion = GetScoreFromMultipleCardsOfASuit(cardIndexes[0], colorsValues, colorsValues);
            }
            else if (!HasOnlySameColorCards(colorsValues))
            {
                handScoreWithHighestCard = GetHighestCardValue(cardIndexes);
            }

            else if (handScoreWithSpecialCombinasion > handScoreWithAddtion && handScoreWithSpecialCombinasion > handScoreWithHighestCard)
            {
                finalHandScore = handScoreWithSpecialCombinasion;
            }
            else if (handScoreWithAddtion > handScoreWithSpecialCombinasion && handScoreWithAddtion > handScoreWithHighestCard)
            {
                finalHandScore = handScoreWithAddtion;
            }
            else if (handScoreWithHighestCard > handScoreWithSpecialCombinasion && handScoreWithHighestCard > handScoreWithAddtion)
            {
                finalHandScore = handScoreWithHighestCard;
            }

            return finalHandScore;
        }
    }
}