package tudorie.marius.Classes;

public class ScreenTime {
	private int []minutes;
	
	public ScreenTime(int[] minutes) {
		this.minutes = minutes;
	}
	
	public void displayMaxScreenTime() {
		int[] max = {this.minutes[0], 0};
		for(int i=0; i<minutes.length; i++) {
			if(this.minutes[i]> max[0]) {
				max[0]= minutes[i];
				max[1] = i;
			}
			
		}
		System.out.println("the day with the most screen time("+max[0]+") is the day no: "+max[1]);
	}
	public void displayMinScreenTime() {
		int[] min = {this.minutes[0], 0};
		for(int i=0; i<minutes.length; i++) {
			if(this.minutes[i]< min[0]) {
				min[0]= minutes[i];
				min[1] = i;
			}
			
		}
		System.out.println("the day with the least screen time("+min[0]+") is the day no: "+min[1]);
	}
}
