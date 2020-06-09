package ro.ase.acs.classes;

import ro.ase.acs.interfaces.Taxable;

public class Car extends Vehicle implements Taxable {
	
	private String color;
	private int capacity;
	
	
	public Car() {
		color = "black";
		capacity = 50;
	}
	
	public Car( String name, int speed, String color, int capacity) {
		super(name, speed);
		this.color = color;
		this.capacity = capacity;
	}
	
	
	

	public String getColor() {
		return color;
	}

	public void setColor(String color) {
		this.color = color;
	}

	public int getCapacity() {
		return capacity;
	}

	public void setCapacity(int capacity) {
		this.capacity = capacity;
	}

	@Override
	public float computeTax() {
		if (capacity <2000) {
			return (float)capacity/1000*50;
		}else
			return (float)capacity/1000*100;
	}

	@Override
	public final void Move() {
		System.out.println("The car is moveing with "+ getSpeed() + " km/h!");
		
	}

	@Override
	public Object clone() throws CloneNotSupportedException {
		Car copy = (Car) super.clone();
		copy.color = color;
		copy.capacity = capacity;
		return copy;
	}
	
	

}
