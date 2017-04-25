public class Deck<T> where T:card{
	private List<T> cards;
	
	private int dealtIndex=0;
	
	public Deck(){
	
	}
	
	public void SetDeckOfCards(List<T> cardDeck){
	cards = cardDeck;
	}
	
	private Random rand =new Random();
	
	public void shuffle(){
		for(int i =0; i<cards.Count(); i++){
			int j= rand.GetNext(cards.Count()-i-1);
			
			T card1 = cards[i];
			T card2 = cards[j];
			
			cards[i] = card2;
			cards[j] = card1;
		}
	}
	
	public int RemainingCards {get{return cards.Count()-dealtIndex;}}
	
	public List<T> DealHand(int number){
		if(RemainingCards==0)
		return null;
		
		List<T> hand = new List<T>(number);
		
		for(int i =0; i<number; i++){
			T card = DealCard();
			if(card!=null)
				hand.Add(card);
		}
	}
	
	public T DealCard(){
		if(RemainingCards ==0)
		return null;
		
		T card = cards[dealtIndex]
		card.MarkUnAvailable();
		dealtIndex++;
		
		return card;
	}
	
	public void print(){
		foreach(var card in cards){
			card.print();
		}
	}
}