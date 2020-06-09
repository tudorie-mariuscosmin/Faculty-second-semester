package ro.ase.acs.main;

import ro.ase.acs.classes.Car;

public class Main {

	public static void main(String[] args) {
		Car c = new Car();
		c.setProducer("Dacia");
		
		int[] array = new int[] {100, 200, 300};
		c.setDistances(array);
		array[0] = 5000;
		System.out.println(c.getDistances()[0]);
		
		Car c2 = (Car)c.clone();
		c.setProducer("ford");
		c.setDistances(array);
		System.out.println(c2.getProducer());
		int[] x = c2.getDistances();
		for(int i=0; i< x.length; i++) {
			System.out.println(x[i]);
		}
	}

}
