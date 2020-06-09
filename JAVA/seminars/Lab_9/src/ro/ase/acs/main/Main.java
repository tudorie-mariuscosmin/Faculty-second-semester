package ro.ase.acs.main;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

import ro.ase.acs.classes.ArraySummingCallable;
import ro.ase.acs.classes.ArraySummingThread;

public class Main {

	public static void main(String[] args) {
		final int noElements = 500_000_000;
		final int noThreads = 4;
		int[] array = new int[noElements];
		
		for(int i=0; i<noElements; i++) {
			array[i] = i+1;
		}
		
		long sum =0;
		long startTime = System.currentTimeMillis();
		
		for(int i=0; i<noElements; i++) {
			sum += array[i];
		}
		
		long endTime = System.currentTimeMillis();
		System.out.printf("Sequential sum= %d, computed in %d ms \r\n", sum, endTime-startTime);
		
		
		
		
		
		sum =0;
		startTime = System.currentTimeMillis();
		
		ArraySummingThread[] threads = new ArraySummingThread[noThreads];  

		for(int i=0; i<noThreads; i++) {
			threads[i] = new ArraySummingThread(array, i*noElements/noThreads, (i+1)*noElements/noThreads);
			threads[i].start();
		}
		
		for(int i=0; i<noThreads; i++) {
			try {
				threads[i].join();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
		}
		
		for(int i=0; i<noThreads; i++) {
			sum+= threads[i].getSum();
		}
		
		endTime = System.currentTimeMillis();
		System.out.printf("Thread array sum= %d, computed in %d ms \r\n", sum, endTime-startTime);
		
		
		
		
		sum =0;
		startTime  =System.currentTimeMillis();
		
		ExecutorService threadPool = Executors.newFixedThreadPool(noThreads);
		
		threads = new ArraySummingThread[noThreads];
		for(int i=0; i<noThreads; i++) {
			threads[i] = new ArraySummingThread(array, i*noElements/noThreads, (i+1)*noElements/noThreads);
			threadPool.execute(threads[i]);
		}
		threadPool.shutdown();
		
		try {
			threadPool.awaitTermination(30, TimeUnit.MINUTES);
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		
		for(int i=0; i<noThreads; i++) {
			sum += threads[i].getSum();
		}
		endTime = System.currentTimeMillis();
		System.out.printf("Thread Pool sum= %d, computed in %d ms \r\n", sum, endTime-startTime);
		
		
		
		
		
		
		sum =0;
		startTime = System.currentTimeMillis();
		ArraySummingCallable[] callables = new ArraySummingCallable[noThreads];
		threadPool = Executors.newFixedThreadPool(noThreads);
		
		List<Future<Long>> results = new ArrayList<Future<Long>>();
		for(int i=0; i< noThreads; i++) {
			callables[i] = new ArraySummingCallable(array, i*noElements/noThreads, (i+1)*noElements/noThreads);
			try {
				results.add(threadPool.submit(callables[i]));
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		
		for(Future<Long> x : results) {
			try {
				sum+= x.get();
			} catch (InterruptedException | ExecutionException e) {
				e.printStackTrace();
			}
		}
		threadPool.shutdown();
		endTime = System.currentTimeMillis();
		System.out.printf("Callable sum= %d, computed in %d ms \r\n", sum, endTime-startTime);
	}

}
