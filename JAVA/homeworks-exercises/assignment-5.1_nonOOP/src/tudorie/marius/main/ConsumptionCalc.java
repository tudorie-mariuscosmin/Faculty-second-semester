package tudorie.marius.main;

public class ConsumptionCalc {

	public static void main(String[] args) {
		float[] liters = {5, 7, 8, 9, 4, 5, 8};
		float[] money = {25, 30, 35, 40, 22, 24, 37}; 
		
		float OverallConsLiters = 0;
		float OverallConsMoney = 0;
		for (int i = 0; i<liters.length; i++)
			OverallConsLiters += liters[i];
		System.out.println("Overall consume in liters is: " + OverallConsLiters);
		System.out.println("Average consume in liters is: " + OverallConsLiters/liters.length);
		
		for (int i = 0; i<money.length; i++)
			OverallConsMoney += money[i];
		System.out.println("Overall consume in money is: " + OverallConsMoney);
		System.out.println("Average consume in money is: " + OverallConsMoney/money.length);
		
		float PricePerLitre= OverallConsMoney/OverallConsLiters;
		System.out.println("The average price of gas is: "+ PricePerLitre);
		
		
	}

}
