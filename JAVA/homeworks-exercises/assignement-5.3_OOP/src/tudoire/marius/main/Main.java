package tudoire.marius.main;

import tudoire.marius.classes.Groups;
import tudoire.marius.classes.Student;
import tudoire.marius.classes.Year;

public class Main {

	public static void main(String[] args) {
		Student stud1 = new Student("marius", new int[] {6, 8, 7, 6, 9});
		Student stud2 = new Student("Teo", new int[] {6, 9, 9, 5, 6});
		Student stud3 = new Student("Ana", new int[] {7, 5, 9, 9, 8});
		Student stud4 = new Student("Ioana", new int[] {6, 9, 7, 8, 5});
		Student stud5 = new Student("Irinel", new int[] {6, 8, 7, 7, 9});
		System.out.println(stud1.getAverage());
		
		Groups group0 = new Groups(1065, new Student[]{stud1, stud2, stud3, stud4, stud5});
		System.out.println(group0.getAvg());
		Groups group1 = new Groups(1065, new Student[]{stud1, stud2, stud3, stud4, stud5});
		Groups group2 = new Groups(1065, new Student[]{stud1, stud2, stud3, stud4, stud5});
		Year y1 = new Year(2020, new Groups[] {group1, group2, group2});
		System.out.println(y1.getAvg());
		

	}

}
