package ro.ase.acs.main;

import ro.ase.acs.classes.SyncedThread;
import ro.ase.acs.classes.UnsyncedThread;

public class Main {

	public static void main(String[] args) {
	
//		UnsyncedThread t1 = new UnsyncedThread("Thread 1");
//		UnsyncedThread t2 = new UnsyncedThread("Thread 2");
//		
//		t1.start();
//		t2.start();
		SyncedThread t3 = new SyncedThread("Thread 3");
		SyncedThread t4 = new SyncedThread("Thread 4");
		
		new Thread(t3).start();
		new Thread(t4).start();
		
		
		Runnable r = ()->{
			try {
				Thread.sleep(2000);
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			System.out.println("Message from another thread!!!");
		};
		
		
		new Thread(r).start();
		
		System.out.println("Main ended");
	
	}

}
