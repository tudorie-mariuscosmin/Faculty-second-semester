package ro.ase.acs.main;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import ro.ase.acs.classes.Car;
import ro.ase.acs.classes.Vehicle;
import ro.ase.acs.interfaces.Taxable;

public class Main {

	public static void main(String[] args) {
		Taxable t = new Car("Dacia", 100, "red", 1400);
		System.out.println(t.computeTax());
		
		Vehicle v = new Car();
		v.move();
		
		//in order to export a jar in Eclipse
		//right-click on the project -> Export
		// -> Java - JAR file
		
		
		Car c = new Car("ford", 90, "black", 10000);
		
		if(c instanceof Cloneable) {
			try {
			Car c2 = (Car)c.clone();
			c.setColor("white");
			System.out.println(c2);
			
			}catch (CloneNotSupportedException e){
				e.printStackTrace();
			}
		}
		
		List<Integer> list = new ArrayList<>();
		
		list.add(3);
		list.add(4);
		list.add(5);
		list.add(6);
		
		
		for(int i=0; i<list.size(); i++) {
			System.out.println(list.get(i));
		}
		
		list.remove(2);
		
		list.add(1,  8);
		System.out.println("------------");
		for(Integer i : list) {
			System.out.println(i);
		}
		System.out.println("------------");
		list.set(0, 1);
		for(Iterator<Integer> it = list.iterator(); it.hasNext();) {
			System.out.println(it.next());
		}
		
		
	}

}
