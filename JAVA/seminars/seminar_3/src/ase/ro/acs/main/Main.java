package ase.ro.acs.main;
import ro.ase.acs.classes.Car;
import ro.ase.acs.classes.Vehicle;
import ro.ase.acs.interfaces.Taxable;



public class Main {

	public static void main(String[] args) {
		//referece types in java: class/ interface / enum
		
		Taxable t = new Car("Dacia", 100, "red", 1400);
		System.out.println(t.computeTax()); 
		Vehicle v = new Car();
		v.Move();
		 
		Car car = new Car("Renault", 120, "yellow", 2000);
		 
		if(car instanceof Cloneable) {
			Car c2;
			try {
				c2 = (Car) car.clone();
				c2.setCapacity(1800);
				System.out.println(car.getCapacity());
			} catch (CloneNotSupportedException e) { 
				e.printStackTrace();
			}
			
			
		}
		
	}

}
