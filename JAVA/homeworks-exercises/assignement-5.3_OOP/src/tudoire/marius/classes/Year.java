package tudoire.marius.classes;

public class Year {
	private int year;
	private Groups[] groups;
	
	public Year(int year, Groups[] groups) {
		this.year = year;
		this.groups = groups;
	}
	
	
	public float getAvg() {
		float total=0;
		for(int i=0; i<groups.length;i++) {
			total+=groups[i].getAvg();
		}
		return total/groups.length;
	}
		
}
