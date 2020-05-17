package ro.ase.acs.main;

import ro.ase.acs.classes.SyncedThread;
import ro.ase.acs.classes.UnsyncedThread;

public class Main {

	public static void main(String[] args) {
		
//		UnsyncedThread t1 = new UnsyncedThread("Tread 1");
//		t1.start();
//		UnsyncedThread t2 = new UnsyncedThread("Tread 2");
//		t2.start();
		
		
		SyncedThread t3 = new SyncedThread("Thread3");
		
		new Thread(t3).start();
		SyncedThread t4 = new SyncedThread("Thread4");
		new Thread(t4).start();
		
		
		Runnable r = () -> System.out.println("message from another thread");
		new Thread(r).start();
		
		System.out.println("Main ended");

	}

}
