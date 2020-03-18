package tudorie.marius.Main;

import java.util.Random;

import tudorie.marius.Classes.ScreenTime;

public class Main {

	public static void main(String[] args) {
		 
		int[] minutes = new int[21];
		 
			Random random = new Random();// for an easier initialization
			for(int i =0; i<21; i++) {
				
				minutes[i] = random.nextInt(150);
				System.out.println("day no "+i+"->"+minutes[i]+" minutes");
			}
			
		ScreenTime programmer = new ScreenTime(minutes);
		programmer.displayMaxScreenTime();
		programmer.displayMinScreenTime();

	}

}
