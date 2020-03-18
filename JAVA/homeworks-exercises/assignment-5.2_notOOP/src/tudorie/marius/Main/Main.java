package tudorie.marius.Main;

import java.util.Random;

public class Main {

	public static void main(String[] args) {
		 int[] minutes = new int[21];
		 
		Random random = new Random();// for an easier initialization
		for(int i =0; i<21; i++) {
			
			minutes[i] = random.nextInt(150);
			System.out.println("day no "+i+"->"+minutes[i]+" minutes");
		}
		
		int maxValue[] = {minutes[0],0};
		 int minValue[] = {minutes[0],0};
		
		for(int i =0; i<minutes.length; i++) {
			if(minutes[i]> maxValue[0]) {
				maxValue[0] = minutes[i];
				maxValue[1] = i;
			}
		}
		
		for(int i=0; i<minutes.length; i++) {
			if(minutes[i]<minValue[0]) {
				minValue[0] = minutes[i];
				minValue[1] = i;
			}
		}
		
		System.out.println("the day with the most screen time("+maxValue[0]+") is the day no: "+maxValue[1]);
		System.out.println("the day with the least amount of screen time("+ minValue[0]+") is the day no: " +minValue[1]);
		
		

	}

}
