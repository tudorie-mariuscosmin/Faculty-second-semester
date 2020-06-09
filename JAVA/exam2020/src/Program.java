import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.Buffer;
import java.util.ArrayList;
import java.util.List;

class Student{
	private int studentId;
	public String name;
	private String classNo;
	private List<String> disciplines;
	
	public Student(int id, String name, String classNo) {
		studentId = id;
		this.name = name;
		this.classNo = classNo;
		this.disciplines = new ArrayList<String>();
	}
	
	public void addD(String d) {
		this.disciplines.add(d);
	}
	
	public List<String> getDisciplines(){
		return this.disciplines;
	}
	
}

class Program {
	public static void main(String[] args) {
		List<Student> students = new ArrayList<Student>();
		try {
			FileInputStream fileInputStream = new FileInputStream("students.txt");
			InputStreamReader inputStreamReader = new InputStreamReader(fileInputStream);
			BufferedReader reader = new BufferedReader(inputStreamReader);
			for(int j=0; j<5; j++) {
				String studentLine =  reader.readLine();
				String[] student =  studentLine.split(",");
				Integer id = Integer.parseInt(student[0]);
				String name = student[1];
				String classNo = student[2];
				Student studentObj = new Student(id, name, classNo);
				students.add(studentObj);
				String disciplinesLine = reader.readLine();
				String[] disciplines = disciplinesLine.split(",");
				for(int i=0; i<disciplines.length; i++) {
					studentObj.addD(disciplines[i]);
				}
			
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		for(Student s :students) {
			for(int i=0; i<s.getDisciplines().size(); i++) {
				if(s.getDisciplines().get(i).equals("Mathematics")) {
					System.out.println(s.name);
				}
			}
		}
		
	}

}

