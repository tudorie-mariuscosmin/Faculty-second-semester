package tudoire.marius.classes;

public class Groups {
	private int groupNo;
	private Student[] students;
	
	
	
	public Groups(int no, Student[] students) {
		groupNo = no;
		this.students = students;	
	}
	
	public float getAvg() {
		float total = 0;
		for(int i=0; i<students.length; i++) {
			 total+=students[i].getAverage();
		}
		return total/students.length;
	}
	
	
	
}
