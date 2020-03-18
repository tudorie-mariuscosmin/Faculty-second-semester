package tudoire.marius.main;

import tudorie.marius.classes.Car;


public class Main {

	public static void main(String[] args) {
		
		Car c1 = new Car("1",new short[] {50, 58, 94});
		System.out.println("IdCar: " +c1.getCId()+" Average: "+c1.getAvgKmPerDay() +
				" Min: " +c1.getMin() + " Max: " + c1.getMax());
		Car c2 = new Car("2",new short[] {94, 107, 92});
		System.out.println("IdCar: " +c2.getCId()+" Average: "+c2.getAvgKmPerDay() + 
				" Min: " + c2.getMin() + " Max: " + c2.getMax());

	}

}
