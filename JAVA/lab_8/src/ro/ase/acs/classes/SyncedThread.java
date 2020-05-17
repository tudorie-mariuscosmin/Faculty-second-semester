package ro.ase.acs.classes;

import java.util.Random;

public class SyncedThread implements Runnable {
	
	private Random random = new Random();
	private String name;
	private static int a =0;
	private static int b =0;
	private static Object Lock = new Object();
	
	public SyncedThread(String name) {
		this.name = name;
	}
	private void method() {
		synchronized (Lock) {
			
		
		System.out.printf(" %s: a=%d b=%d \r\n", name, a, b);
		a++;
		try {
			Thread.sleep(random.nextInt(3000));
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		b++;
		}
	}
	
	
	@Override
	public void run() {
		for(int i =0; i<3; i++) {
			method();
		}
		
	}

	
}
