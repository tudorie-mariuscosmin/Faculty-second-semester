package ro.ase.acs.main;

import ro.ase.acs.classes.SyncedThread;
import ro.ase.acs.classes.UnsyncedThread;

public class Main {

	public static void main(String[] args) {
		
//		UnsyncedThread t1 = new UnsyncedThread("Thread 1");
//		t1.start();
//		UnsyncedThread t2 = new UnsyncedThread("Thread2");
//		t2.start();
		
		SyncedThread t3 = new SyncedThread("thread3");
		new Thread(t3).start();
		SyncedThread t4 = new SyncedThread("thread4");
		new Thread(t4).start();
		
		System.out.println("main ended");
		
		Runnable r = ()->{
			try {
				Thread.sleep(2000);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			System.out.println("message from another thread");
		};
		new Thread(r).start();
		

	}

}
 