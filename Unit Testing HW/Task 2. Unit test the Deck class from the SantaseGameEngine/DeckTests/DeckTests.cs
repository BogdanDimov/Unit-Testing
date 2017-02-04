namespace DeckTests
{
    using NUnit.Framework;
    using DeckClass.Cards;
    using System.Collections.Generic;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void TrumpCardShouldBeNonNullable()
        {
            IDeck deck = new Deck();
            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void TrumpCardShouldBeRandom()
        {
            const int NumberOfRandomDecks = 25;
            var lastCard = new Deck().TrumpCard;
            for (int i = 0; i < NumberOfRandomDecks - 1; i++)
            {
                IDeck deck = new Deck();
                if (!deck.TrumpCard.Equals(lastCard))
                {
                    return;
                }

                lastCard = deck.TrumpCard;
            }

            Assert.Fail($"{NumberOfRandomDecks} times generated the same trump card!");
        }

        [Test]
        public void CardsLeftShouldBe24ForANewDeck()
        {
            IDeck deck = new Deck();
            Assert.AreEqual(24, deck.CardsLeft);

        }

        [Test]
        public void CardsLeftShouldBe23AfterDrawingOneCard()
        {
            var deck = new Deck();
            deck.GetNextCard();
            Assert.AreEqual(23, deck.CardsLeft);
        }

        [Test]
        public void CardsLeftShouldBe0AfterDrawing24Cards()
        {
            var deck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(0, deck.CardsLeft);
        }

        [Test]
        public void GetNextCardShouldNotChangeTheTrumpCard()
        {
            var deck = new Deck();
            var trumpBefore = deck.TrumpCard;
            deck.GetNextCard();
            var trumpAfter = deck.TrumpCard;
            Assert.AreEqual(trumpBefore, trumpBefore);
        }

        [Test]
        public void GetNextCardShouldReturnDifferentNonNullCardEveryTime()
        {
            var deck = new Deck();
            var cards = new HashSet<Card>();
            var cardsCount = deck.CardsLeft;
            for (int i = 0; i < cardsCount; i++)
            {
                var card = deck.GetNextCard();
                Assert.IsNotNull(card);
                Assert.IsFalse(cards.Contains(card), $"Duplicate card drawn \"{card}\"");
                cards.Add(card);
            }

        }

        [Test]
        public void ChangeTrumpCardShouldWorkProperly()
        {
            var deck = new Deck();
            var card = Card.GetCard(CardSuit.Spade, CardType.Nine);
            deck.ChangeTrumpCard(card);
            var trumpCard = deck.TrumpCard;
            Assert.AreEqual(card, trumpCard);
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheLastCardInTheDeck()
        {
            var deck = new Deck();
            var card = Card.GetCard(CardSuit.Club, CardType.Ace);
            deck.ChangeTrumpCard(card);
            var cardsCount = deck.CardsLeft;
            for (int i = 0; i < cardsCount - 1; i++)
            {
                deck.GetNextCard();
            }

            var lastCard = deck.GetNextCard();
            Assert.AreEqual(card, lastCard);
        }
    }
}
