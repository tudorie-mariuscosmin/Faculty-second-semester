package tudorie.marius.main;

public class Main {

	public static void main(String[] args) {
		int carsNo = 2;
		int days = 3;
		short[][] kmPerDay = 
				new short[][] {{50, 58, 94}, {94, 107, 92}};
		float[] avgKmPerDay = new float[carsNo];
		float[] min = new float [carsNo];
		float[] max = new float [carsNo];
				
		for (int i = 0; i < carsNo; i++) {			
			avgKmPerDay[i] = 0;
			for (int j = 0; j < days; j++) {
				avgKmPerDay[i] += kmPerDay[i][j];
			}
			avgKmPerDay[i] /= days;
		}
		
		for (int i = 0; i < carsNo; i++) {
			min[i] = kmPerDay[i][0];
			max[i] = kmPerDay[i][0];
			for (int j = 0; j < days; j++)
			{
				if(kmPerDay[i][j] < min[i])
					min[i] = kmPerDay[i][j];
				if(kmPerDay[i][j] > max[i])
					max[i] = kmPerDay[i][j];
			}
		}
		
		for (int i = 0; i < carsNo; i++) {
			System.out.println("The average km/day for the car "+ i +" is = "+
					avgKmPerDay[i]);
			System.out.println("The min km/day for the car "+ i +" is = "+
					min[i]);
			System.out.println("The max km/day for the car "+ i +" is = "+
					max[i]);
		}

	}

}
