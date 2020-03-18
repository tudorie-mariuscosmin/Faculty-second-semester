package tudorie.marius.classes;

public class Car {
	private String carId;
	private short[] kmPerDay;
	private float avgKmPerDay;
	
	
	public Car(String carId, short[] kmPerDay) {
		this.carId = carId;
		this.kmPerDay = kmPerDay;
	}
	

	public String getCId() {
		return this.carId;
	}
	
	public short[] getkmPerDay() {
		return this.kmPerDay;
	}
	
	public void setCId(String carId) {
		this.carId = carId;
	}
	
	public void setKms(short[] kmPerDay) {
		this.kmPerDay = kmPerDay;
	}
	
	public float getAvgKmPerDay() {
		this.avgKmPerDay = calcAvgKmPerDay();
		return this.avgKmPerDay;
	}
	
	private float calcAvgKmPerDay() {
		float result = 0.0f;
	
		for (int j = 0; j < kmPerDay.length; j++) {
			result = result + this.kmPerDay[j];
		}

		result = result / kmPerDay.length;
		return result;
	}
	
	public float getMax()
	{
		float max=kmPerDay[0];
		
		for(int i=0;i<kmPerDay.length;i++)
			if(kmPerDay[i] > max)
				max=kmPerDay[i];
		return max;	
	}
	
	public float getMin()
	{
		float min=kmPerDay[0];
		
		for(int i=0;i<kmPerDay.length;i++)
			if(kmPerDay[i] < min)
				min=kmPerDay[i];
		return min;	
	}
	
	
	
	
	
}
