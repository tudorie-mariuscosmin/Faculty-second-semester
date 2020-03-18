package tudorie.marius.classes;

public class ConsumeCalc {
	private double[] gas;
	private double[] money;
	
	
	public ConsumeCalc(double[] gas, double[] money) {
		this.gas = gas;
		this.money = money;
	}
	
	public double  getTotalGas() {
		double total = 0;
		for(int i=0; i<this.gas.length; i++) {
			total += gas[i];
		}
		return total;
	}
	
	public double getTotalMoney() {
		double total = 0;
		for(int i=0; i<this.money.length; i++) {
			total += this.money[i];
		}
		return total;
	}
	
	public double getAvgGas() {
		return this.getTotalGas()/this.gas.length;
	}
	
	public double getAvgMoney() {
		return this.getTotalMoney()/this.money.length;
	}
	
	public double getAvgGasPrice() {
		return this.getTotalMoney()/this.getTotalGas();
	}
	
	
	
}
