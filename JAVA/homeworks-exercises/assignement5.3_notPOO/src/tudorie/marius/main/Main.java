package tudorie.marius.main;

public class Main {

	public static void main(String[] args) {
		int studentsNo = 2;
		int lectNo = 3;
		float sumgroup = 0;
		short[][] studentsMarksAtDisciplines = 
				new short[][] {{5, 5, 9}, {9, 10, 9}};
		float[] avgStudMark = new float[studentsNo];
				
		for (int i = 0; i < studentsNo; i++) {
			avgStudMark[i] = 0;
			for (int j = 0; j < lectNo; j++) {
				avgStudMark[i] += studentsMarksAtDisciplines[i][j];
			}
			avgStudMark[i] /= lectNo;
		}
		
		for (int i = 0; i < studentsNo; i++) {
			System.out.println("The average mark for the student "+ i +" is = "+
					avgStudMark[i]);
		}
		for (int i = 0; i< studentsNo; i++) 
			 sumgroup += avgStudMark[i];
		float avgGroup = sumgroup /= studentsNo;
		
		System.out.println("The average mark for the group is = " + avgGroup);
	}

}
