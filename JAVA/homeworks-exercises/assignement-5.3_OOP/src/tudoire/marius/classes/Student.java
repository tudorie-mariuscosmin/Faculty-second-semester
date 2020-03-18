package tudoire.marius.classes;

public class Student {
	private String name;
	private int[] grades;
	
	public Student(String name, int[] grades) {
		this.name = name;
		this.grades = new int[grades.length];
		for(int i=0; i<grades.length; i++) {
			this.grades[i] = grades[i];
		}
	}
	
	
	public float getAverage() {
		float total = 0;
		
		for (int i=0; i<grades.length; i++) {
			total+= grades[i];
		}
		float avg = total/grades.length;
		return avg;
	}
	
	
	
	
	
	
	
}
