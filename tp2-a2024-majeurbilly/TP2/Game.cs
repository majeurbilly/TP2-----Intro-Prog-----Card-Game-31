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
            return (index % 13) + 1;
        }

        public static void DistributeCard(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i] == false)
                {
                    int newCarte;
                    
                    do
                    {
                        newCarte = new Random().Next(0, 52);


                    } while (!availableCards[newCarte]);
                    cardValues[i] = newCarte;
                    availableCards[newCarte] = false;
                }
            }
        }

        public static int GetScoreFromCardValue(int cardValue)
        {
            return cardValue % 13;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            //todo: pas fini 
            int handScore = 0;
            int[] handCards = new int[cardIndexes.Length];


            return 0;
        }

        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }


        public static int GetHighestCardValue(int[] cardsValues)
        {
            int highestValue = 0;
            foreach (int i in cardsValues)
            {
                if (cardsValues[i] > highestValue)
                {
                    highestValue = cardsValues[i];
                }
            }
            return highestValue;
        }

        public static bool HasOnlySameColorCards(int[] cardValues)
        {
            int temp = GetSuitFromCardIndex(cardValues[0]);
            for (int i = 1; i < cardValues.Length; i++)
            {
                if (GetSuitFromCardIndex(cardValues[i]) != temp)
                {
                    return false;
                }
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
                if (!FACES.Contains(GetValueFromCardIndex(values[i])))
                {
                    return false;
                }

                counter += GetValueFromCardIndex(values[i]);
            }

            if (counter != ALL_FACES_SUM)
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

        public static bool HasSameColorSequence(int[] values, int[] colors)
        {
            for (int i = 1; i < colors.Length; i++)
            {
                if (GetSuitFromCardIndex(values[i]) != colors[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasSequence(int[] values)
        {
            throw new NotImplementedException();
        }

        public static int GetScoreFromMultipleCardsOfASuit(int suit, int[] values, int[] suits)
        {
            throw new NotImplementedException();
        }
    }
}