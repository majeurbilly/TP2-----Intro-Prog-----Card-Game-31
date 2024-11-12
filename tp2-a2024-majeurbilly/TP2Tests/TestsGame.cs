using Xunit;
using TP2;
namespace TP2Tests
{
    public class TestsGame
    {
         /* PROF : nous testons certaines fonctions avec 5 choix, car il est demand� que vos
         fonctions soient bonnes en g�n�ral et non seulement pour le jeu du 31 (lorsque applicable).*/
         
        [Fact]
        public void CanGetNormalCardScore()
        {
            const int EXPECTED = 9;
            // Arrange
            // 5
            int cardValue = Game.NINE;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(EXPECTED, score);
        }
       
        [Fact]
        public void CanGetFaceCardScore()
        {
            // Arrange
            // Roi
            int cardValue = Game.KING;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(Game.FACES_SCORE, score);
        }

        [Fact]
        public void CanGetAceCardScore()
        {
            // Arrange
            // Roi
            int cardValue = Game.ACE;

            // Act
            int score = Game.GetScoreFromCardValue(cardValue);

            // Assert
            Assert.Equal(Game.ACES_SCORE, score);
        }
        
        
        [Fact]
        public void CanGetHighestCardValueOnNormalHand()
        {
            // Arrange
            // 3, 7, 6, Reine, 4
            int[] values = { 2, 6, 5, 11, 3 };

            // Act
            int highestCard = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.QUEEN, highestCard);
        }
         
        [Fact]
        public void CanGetHighestCardValueOnConstantHand()
        {
            // Arrange
            // 3, 3, 3, 3, 3
            int[] values = { 2, 2, 2, 2, 2 };

            // Act
            int highestDice = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.THREE, highestDice);
        }
      
        [Fact]
        public void CanGetHighestCardValueWithAceInHand()
        {
            // Arrange
            // 3, Roi, As, 7, 4
            int[] values = { 2, 12, 0, 6, 3 };

            // Act
            int highestDice = Game.GetHighestCardValue(values);

            // Assert
            Assert.Equal(Game.ACE, highestDice);
        }
         
       
        [Fact]
        public void CantFindOnlySameColorIfDifferentColorsPresent()
        {
            // Arrange
            // Coeur, Diamant, Pique, Tr�fle, Coeur
            int[] suits = { 0, 1, 2, 3, 0 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.False(onlySameColor);
        }
   
        [Fact]
        public void CanFindOnlySameColorCardsAllRed()
        {
            // Arrange
            // Coeur, Diamant, Diamant, Coeur, Coeur
            int[] suits = { 0, 1, 1, 0, 0 };

            // Act
            bool onlySameColor = Game.HasOnlySameColorCards(suits);

            // Assert
            Assert.True(onlySameColor);
        }
        
   [Fact]
   public void CanFindOnlySameColorCardsAllBlack()
   {
       // Arrange
       // Pique, Tr�fle, Tr�fle, Pique, Pique
       int[] suits = { 2, 3, 3, 2, 2 };

       // Act
       bool onlySameColor = Game.HasOnlySameColorCards(suits);

       // Assert
       Assert.True(onlySameColor);
   }
   [Fact]
   public void CantFindOnlySameColorCardsIfNonExistentColorPresent()
   {
       // Arrange
       // Pique, Tr�fle, Pique, ?, Pique
       int[] suits = { 2, 3, 2, 4, 2 };

       // Act
       bool onlySameColor = Game.HasOnlySameColorCards(suits);

       // Assert
       Assert.False(onlySameColor);
   }

   [Fact]
   public void CantFindOnlySameColorCardsIfOnlyNonExistentColorsPresent()
   {
       // Arrange
       // ?, ?, ?, ?, ?
       int[] suits = { 4, 5, 6, 7, 8 };

       // Act
       bool onlySameColor = Game.HasOnlySameColorCards(suits);

       // Assert
       Assert.False(onlySameColor);
   }
   

   [Fact]
   public void CantFindAllSameCardValuesIfNotPresent()
   {
       // Arrange
       // As, 8, Valet, 10, Roi
       int[] values = { 0, 7, 10, 9, 12 };

       // Act
       bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

       // Assert
       Assert.False(hasAllSameCardValues);
   }
   
   [Fact]
   public void CantFindAllSameCardValuesIfMajorityOfCardsHaveSameValue()
   {
       // Arrange
       // 4, 4, 4, 5, 5
       int[] values = { 3, 3, 3, 4, 4 };

       // Act
       bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

       // Assert
       Assert.False(hasAllSameCardValues);
   }
   
   [Fact]
   public void CanFindAllSameCardValuesIfPresent()
   {
       // Arrange
       // 10, 10, 10, 10, 10
       int[] values = { 9, 9, 9, 9, 9 };

       // Act
       bool hasAllSameCardValues = Game.HasAllSameCardValues(values);

       // Assert
       Assert.True(hasAllSameCardValues);
   }

   [Fact]
   public void CantFindAllFacesIfNonePresent()
   {
       // Arrange
       // 6, 10, As
       int[] values = { 5, 9, 0 };

       // Act
       bool hasAllFaces = Game.HasAllFaces(values);

       // Assert
       Assert.False(hasAllFaces);
   }
   
   [Fact]
   public void CantFindAllFacesIfNotOnlyFacesPresent()
   {
       // Arrange
       // Valet, Reine, As
       int[] values = { 10, 11, 0 };

       // Act
       bool hasAllFaces = Game.HasAllFaces(values);

       // Assert
       Assert.False(hasAllFaces);
   }
   [Fact]
   public void CantFindAllFacesIfMultipleSameFacesPresent()
   {
       // Arrange
       // Valet, Roi, Roi
       int[] values = { 10, 12, 12 };

       // Act
       bool hasAllFaces = Game.HasAllFaces(values);

       // Assert
       Assert.False(hasAllFaces);
   }
   [Fact]
   public void CanFindAllFacesIfPresent()
   {
       // Arrange
       // Valet, Reine, As
       int[] values = { 10, 11, 12 };

       // Act
       bool hasAllFaces = Game.HasAllFaces(values);

       // Assert
       Assert.True(hasAllFaces);
   }
   [Fact]
   public void CanFindAllFacesIfPresentNotInOrder()
   {
       // Arrange
       // Valet, Reine, As
       int[] values = { 12, 10, 11 };

       // Act
       bool hasAllFaces = Game.HasAllFaces(values);

       // Assert
       Assert.True(hasAllFaces);
   }
   
   [Fact]
   public void CantFindOnlyFacesIfNonePresent()
   {
       // Arrange
       // 4, 5, 6, 7, 8
       int[] values = { 3, 4, 5, 6, 7 };

       // Act
       bool hasOnlyFaces = Game.HasOnlyFaces(values);

       // Assert
       Assert.False(hasOnlyFaces);
   }

   [Fact]
   public void CantFindOnlyFacesIfNotOnlyFacesPresent()
   {
       // Arrange
       // 4, 5, 6, Valet, Roi
       int[] values = { 3, 4, 5, 10, 12 };

       // Act
       bool hasOnlyFaces = Game.HasOnlyFaces(values);

       // Assert
       Assert.False(hasOnlyFaces);
   }

   [Fact]
   public void CanFindOnlyFacesIfPresent()
   {
       // Arrange
       // Reine, Valet, Roi, Valet, Roi
       int[] values = { 11, 10, 11, 10, 12 };

       // Act
       bool hasOnlyFaces = Game.HasOnlyFaces(values);

       // Assert
       Assert.True(hasOnlyFaces);
   }

   [Fact]
   public void CanFindOnlyFacesIfAllSameFace()
   {
       // Arrange
       // Valet, Valet, Valet, Valet, Valet
       int[] values = { 10, 10, 10, 10, 10 };

       // Act
       bool hasOnlyFaces = Game.HasOnlyFaces(values);

       // Assert
       Assert.True(hasOnlyFaces);
   }

   [Fact]
   public void CanFindOnlyFacesIfAllFacesPresent()
   {
       // Arrange
       // Reine, Valet, Roi
       int[] values = { 12, 10, 11, };

       // Act
       bool hasOnlyFaces = Game.HasOnlyFaces(values);

       // Assert
       Assert.True(hasOnlyFaces);
   }
   
  
   [Fact]
   public void CantFindSameColorSequenceIfNonePresent()
   {
       // Arrange
       // 4, 7, 2, Valet, Roi
       int[] values = { 3, 6, 1, 10, 12 };
       // Coeur, Diamant, Pique, Tr�fle, Coeur
       int[] suits = { 0, 1, 2, 3, 0 };

       // Act
       bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

       // Assert
       Assert.False(hasSameColorSequence);
   }

   [Fact]
   public void CantFindSameColorSequenceIfOnlySequencePresent()
   {
       // Arrange
       // 4, 7, 5, 6, 8 (4, 5, 6, 7, 8)
       int[] values = { 3, 6, 4, 5, 7 };
       // Coeur, Diamant, Pique, Tr�fle, Coeur
       int[] suits = { 0, 1, 2, 3, 0 };

       // Act
       bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

       // Assert
       Assert.False(hasSameColorSequence);
   }

   [Fact]
   public void CantFindSameColorSequenceIfOnlySameColorPresent()
   {
       // Arrange
       // 4, 7, 2, Valet, Roi
       int[] values = { 3, 6, 1, 10, 12 };
       // Coeur, Diamant, Diamant, Diamant, Coeur
       int[] suits = { 0, 1, 1, 1, 0 };

       // Act
       bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

       // Assert
       Assert.False(hasSameColorSequence);
   }
  
   [Fact]
   public void CanFindSameColorSequenceIfPresent()
   {
       // Arrange
       // 4, As, 5, 3, 2 (As, 2, 3, 4, 5)
       int[] values = { 3, 0, 4, 2, 1 };
       // Coeur, Diamant, Diamant, Diamant, Coeur
       int[] suits = { 0, 1, 1, 1, 0 };

       // Act
       bool hasSameColorSequence = Game.HasSameColorSequence(values, suits);

       // Assert
       Assert.True(hasSameColorSequence);
   }
   
   [Fact]
   public void CantFindSequenceIfNonePresent()
   {
       // Arrange
       // 4, Valet, 2, 5, 8
       int[] values = { 3, 10, 1, 4, 7 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.False(hasSequence);
   }

   [Fact]
   public void CanFindSequenceIfPresent()
   {
       // Arrange
       // 4, 5, 6, 7, 8
       int[] values = { 3, 4, 5, 6, 7 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.True(hasSequence);
   }
   [Fact]
   public void CanFindSequenceWithAce()
   {
       // Arrange
       // As, 2, 3, 4, 5
       int[] values = { 0, 1, 2, 3, 4 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.True(hasSequence);
   }
   [Fact]
   public void CanFindSequenceWithFaces()
   {
       // Arrange
       // 9, 10, Valet, Reine, Roi
       int[] values = { 8, 9, 10, 11, 12 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.True(hasSequence);
   }
   [Fact]
   public void CantFindSequenceWithAceAndFaces()
   {
       // Arrange
       // 10, Valet, Reine, Roi, As
       int[] values = { 9, 10, 11, 12, 0 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.False(hasSequence);
   }
   [Fact]
   public void CanFindSequenceNotInOrder()
   {
       // Arrange
       // 5, 8, 7, 6, 4 (4, 5, 6, 7, 8)
       int[] values = { 4, 7, 6, 5, 3 };

       // Act
       bool hasSequence = Game.HasSequence(values);

       // Assert
       Assert.True(hasSequence);
   }
   
    [Fact]
    public void ShouldGet0WhenTargetSuitNotInSuits()
    {
        // Arrange
        const int EXPECTED = 0;
        // Coeur
        int suit = 0;
        // 4, Valet, As
        int[] values = { 3, 10, 0 };
        // Diamant, Diamant, Diamant
        int[] suits = { 1, 1, 1 };

        // Act
        int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

        // Assert
        Assert.Equal(EXPECTED, score);
    }
    
    [Fact]
    public void ShouldGetRightScoreWithOneCardFromTargetSuit()
    {
        // Arrange
        const int EXPECTED = 4;
        // Coeur
        int suit = 0;
        // 4, Valet, As
        int[] values = { 3, 10, 0 };
        // Coeur, Diamant, Diamant
        int[] suits = { 0, 1, 1 };

        // Act
        int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

        // Assert
        Assert.Equal(EXPECTED, score);
    }
 
    [Fact]
    public void ShouldGetRightScoreWithMultipleCardsFromTargetSuit()
    {
        // Arrange
        const int EXPECTED = 14;
        // Coeur
        int suit = 0;
        // 4, Valet, As, Reine, 6
        int[] values = { 3, 10, 0, 11, 5 };
        // Coeur, Diamant, Diamant, Coeur, Pique
        int[] suits = { 0, 1, 1, 0, 2 };

        // Act
        int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

        // Assert
        Assert.Equal(EXPECTED, score);
    }

 [Fact]
 public void ShouldGetMaxScoreWithRightCombinationFromTargetSuit()
 {
     // Arrange
     // Tr�fle
     int suit = 3;
     // Roi, Valet, As
     int[] values = { 12, 10, 0, };
     // Tr�fle, Tr�fle, Tr�fle
     int[] suits = { 3, 3, 3 };

     // Act
     int score = Game.GetScoreFromMultipleCardsOfASuit(suit, values, suits);

     // Assert
     Assert.Equal(Game.MAX_SCORE, score);
 }

[Fact]
public void CanGetBestScoreFromCombinationScoreIfBetterThenAdditionScore()
{
  // Arrange
  // 2, 6, 9 de Coeur (M�me couleur = 24, Addition = 17)
  int[] indexes = { 1, 5, 8 };

  // Act
  int score = Game.GetHandScore(indexes);

  // Assert
  Assert.Equal(Game.SAME_COLOR_SCORE, score);
}

[Fact]
public void CanGetBestScoreFromAdditionScoreIfBetterThenCombinationScore()
{
 const int EXPECTED = 30;
 // Arrange
 // 10, Valet, Reine de Pique (Suite de m�me couleur = 28, Addition = 30)
 int[] indexes = { 35, 36, 37 };

 // Act
 int score = Game.GetHandScore(indexes);

 // Assert
 Assert.Equal(EXPECTED, score);
}

[Fact]
public void CanGetBestScoreFromSingleCardIfNoCombinationAndNoCardsFromSameSuit()
{
 const int EXPECTED = 11;
 // Arrange
 // As de Coeur, Valet de Pique, 6 de Diamant (Aucune combinaison sp�ciale, Carte la plus forte = 11)
 int[] indexes = { 0, 36, 18 };

 // Act
 int score = Game.GetHandScore(indexes);

 // Assert
 Assert.Equal(EXPECTED, score);
}
[Fact]
public void CanGetBestScoreFromSingleCardIfNoCombinationAndAdditionOfCardsFromSameSuitIsLower()
{
 const int EXPECTED = 11;
 // Arrange
 // As de Coeur, 4 de Pique, 6 de Pique (Aucune combinaison sp�ciale, Carte la plus forte = 11, Addition = 10)
 int[] indexes = { 0, 29, 31 };

 // Act
 int score = Game.GetHandScore(indexes);

 // Assert
 Assert.Equal(EXPECTED, score);
}


    }
}