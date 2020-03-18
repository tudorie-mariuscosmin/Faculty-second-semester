package tudorie.marius.Main;

import tudorie.marius.classes.ConsumeCalc;

public class Main {

	public static void main(String[] args) {
	
		ConsumeCalc consumption = new ConsumeCalc(new double[] {10, 12, 11, 9,14}, new double[] {50, 70, 65, 47, 70});
		System.out.println(consumption.getAvgGas());
		System.out.println(consumption.getAvgMoney());
		System.out.println(consumption.getAvgGasPrice());

	}

}
