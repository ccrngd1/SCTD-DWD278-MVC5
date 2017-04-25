public class Cell{
	private bool isBomb;
	private bool isExposed;
	private bool isGuess;
	private int neighborBombNumber;
	
	public Cell( ){ 
	}
	
	public bool IsBomb { get { return isBomb;}}
	
	public bool Expose() {
		isExposed = true;
		return !isBomb;
	}
	
	public void Guess(){
		if(!isExposed)
			isGuess = !isGuess;
	}
	
	public void IncreaseNumber(){
		neighborBombNumber++;
	}
	
	public bool IsGuess { get { return isGuess;}}
	
	public string ToString(){
		return GetUndersideState();
	}
	
	public string SurfaceState 
	{ 
		get{
			if(isExposed)
				return GetUndersideState();
			else if(isGuess)
				return "?";
			else
				return "-";
		}
	}
	
	public string GetUndersideState{
		get{
            if (isBomb)
                return "*";
            else if (number > 0)
                return number.ToString();
            else
                return "X";
		}
	}
}