public class Board{
	private int rowNumber;
	private int colNumber;
	
	private Cell[,] cells;
	
	private int unexposedCellsRemaining;
	private int bombsTotal;
	private int bobmsRemaining;
	
	public Board(int rs, int cs, int bs){
		rowNumber = rs;
		colNumber = cs;
		bombsTotal = bs;
		
		InitBoard();  
		
		unexposedCellsRemaining = rowNumber * colNumber - bombsTotal;
		
		bombsRemaining = bs;
	}
	
	public void InitBoard(){
		cells = new Cell[rowNumber, colNumber];
		 		
		for(int i=0; i< rowNumber; i++){
			for(int j=0; j< colNumber; j++){
				cells[i,j] = new Cell(false);
			}
		}
		
		Random r = new Random();
		
		for(int i =0; i<bombsTotal; i++){
			int cellNumber = r.GetNext(rowNumber * colNumber);
			
			int r=0;
			int c=0;
			
			r = Math.Floor(cellNumber/colNumber);
			c = cellNumber%rowNumber;

            if (!cells[r, c].IsBomb)
            {
                cells[r, c].SetBomb();

                SetNumberedCell(r - 1, c);
                SetNumberedCell(r - 1, c - 1);
                SetNumberedCell(r - 1, c + 1);
                SetNumberedCell(r, c - 1);
                SetNumberedCell(r, c + 1);
                SetNumberedCell(r + 1, c - 1);
                SetNumberedCell(r + 1, c);
                SetNumberedCell(r + 1, c + 1);
            }
            else
                i--;
		}
	}

    private void SetNumberedCell(int rowPos, int colPos)
    {
        if (rowPos < 0 || rowPos > rowNumber) return;
        if (colPos < 0 || colPos > colNumber) return;

        cells[rowPos, colPos].IncreaseNumber;
    }
	
	//int[] Offset = new[]{-1,0,1};	
	
	//public void SetNumberedCells(){
	//	for(int i=0; i<rowNumber; i++){
	//		for(int j=0; j<colNumber; j++){
	//			if(!cells[i,j].IsBomb) continue;
				
	//			foreach(var offR in Offset){
	//				foreach(var offC in Offset){
	//					if(i+offR>0 && i+offR<rowNumber 
	//					&& j+offC>0 && j+offC<rowNumber)
	//						cells[i+offR, j+offC].IncreaseNumber();
	//				}
	//			}				
	//		}
	//	}
	//}
}