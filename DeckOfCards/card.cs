public abstract class Card{

private bool available = true;

protected int faceValue;
protected Suit suit;

public card(int c, suit s){

}

//also liked the idea of taking a number 1-52
public card (int Rnd1to52){
	suit = Rnd1to52/13;
	c = Rnd1To52%13;
}

public abstract int Value();

public Suit Suit{get{return suit}}
public bool IsAvailable {get{return available;}}
public void MarkUnAvailable(){available=false;}
public void MarkAvailable(){available = true;}

private const string[] faceValues = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

public void print(){
	Console.WriteLine(faceValues[faceValue]);
	
	Console.WriteLine(suit.ToString()[0]);
}
}