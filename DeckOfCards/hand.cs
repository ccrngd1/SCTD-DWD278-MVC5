public class Hand<T> where T:card{
	protected List<T> cards = new List<T>();
	
	public int score(){
		int score = 0;
		
		foreach(var card in cards){
			score+=card.Value;
		}
		return score;
	}
	
	public void addCard(T card){
		cards.Add(card);
	}
	
	public void print(){
		foreach(var card in cards){
			card.print();
		}
	}
}