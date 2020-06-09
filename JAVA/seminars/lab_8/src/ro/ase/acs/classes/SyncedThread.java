package ro.ase.acs.classes;

import java.util.Random;

public class SyncedThread implements Runnable {

	public static Random random = new Random();
	public static int a;
	public static int b;
	private String name;
	private static Object objLock = new Object();
	
	
	
	public SyncedThread(String name) {
		this.name = name;
	}
	
	public void method() {
		synchronized (objLock) {
			System.out.printf("%s: a=%d, b=%d \r\n", name, a,b);
			a++;
			try {
				Thread.sleep(random.nextInt(3000));
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			b++;
		}
	}
	@Override
	public void run() {
		for(int i=0; i<3;i++) {
			method();
		}
		
	}
	
	
	
	
}
