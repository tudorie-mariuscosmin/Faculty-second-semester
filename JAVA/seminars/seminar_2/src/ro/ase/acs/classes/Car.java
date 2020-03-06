package ro.ase.acs.classes;

public class Car {
	private String producer;
	private float price;
	
	public enum FuelType {gas, diesel, electric};
	private FuelType fuelType;
	private int [] distances;
	
	public Car() {
		producer = "";
		price = 0;
		fuelType = FuelType.gas;
		distances = new int[1];
		distances[0] = 100;
	}

	public int[] getDistances() {
		int[] copy = new int[distances.length];
		System.arraycopy(distances, 0, copy, 0, distances.length);
		return copy;
	}

	public void setDistances(int[] distances) {
		this.distances = new int[distances.length];
		for(int i=0; i<distances.length; i++) {
			this.distances[i] = distances[i];
		}
	}

	public String getProducer() {
		return producer;
	}

	public void setProducer(String producer) {
		this.producer = producer;
	}

	public float getPrice() {
		return price;
	}

	public void setPrice(float price) {
		this.price = price;
	}

	public FuelType getFuelType() {
		return fuelType;
	}

	public void setFuelType(FuelType fuelType) {
		this.fuelType = fuelType;
	}

	@Override
	public Object clone() {
		Car car = new Car();
		//car.producer = producer; // string is an imutable class 
		car.producer = new String(producer);
		car.price = price;
		car.fuelType = fuelType;
		car.distances = getDistances();
		return car;
	}
	
	
	
	

}
