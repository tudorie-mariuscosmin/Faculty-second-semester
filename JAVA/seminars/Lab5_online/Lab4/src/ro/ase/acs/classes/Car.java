package ro.ase.acs.classes;

import ro.ase.acs.interfaces.Taxable;

//inheritance in Java is done with extends and implements
public final class Car extends Vehicle implements Taxable, Comparable<Car> {
	private String color;
	private int capacity;
	
	public Car() {
		//base default constructor call
		super();
		color = "black";
		capacity = 50;
	}
	
	public Car(String name, int speed, String color, int capacity) {
		//base constructor call
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

	//we override the clone method again
	//and we call the base implementation
	@Override
	public Object clone() throws CloneNotSupportedException {
		Car copy = (Car)super.clone();
		copy.color = color;
		copy.capacity = capacity;
		return copy;
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("Car [color=");
		builder.append(color);
		builder.append(", capacity=");
		builder.append(capacity);
		builder.append(", name=");
		builder.append(getName());
		builder.append(", getSpeed()=");
		builder.append(getSpeed());
		builder.append("]");
		return builder.toString();
	}

	//The toString method is called in order to
	//convert to object into a String
	//for example when we want to display it to the console
	//
	//String concatenation is not the best approach
	//because the String class is immutable
	

	@Override
	public float computeTax() {
		float tax = 0;
		if(capacity < 2000) {
			tax = (float)capacity / 1000 * 50;
		}
		else {
			tax = (float)capacity / 1000 * 100;
		}
		return (tax > MIN_TAX) ? tax : MIN_TAX;
	}

	@Override
	public final void move() {
		System.out.println("The car is moving with " + getSpeed() + 
				" km/h");
	}

	@Override
	public int compareTo(Car o) {
		if(capacity< o.capacity)
			return -1;
		else if(capacity == o.capacity)
			return 0;
		else
			return 1;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + capacity;
		result = prime * result + ((color == null) ? 0 : color.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Car other = (Car) obj;
		if (capacity != other.capacity)
			return false;
		if (color == null) {
			if (other.color != null)
				return false;
		} else if (!color.equals(other.color))
			return false;
		return true;
	}

	
	
//	@Override
//	public boolean equals(Object obj) {
//		if(obj instanceof Car) {
//			Car o = (Car)obj;
//			return(getName().equals(o.getName()) && getSpeed() == o.getSpeed() && color.equals(o.color)&& capacity == o.capacity);
//		}else
//			return false;
//		
//	}
//
//	@Override
//	public int hashCode() {
//		return((31* getName().hashCode() + getSpeed()) *31* color.hashCode() +capacity);
//	}
	

}
