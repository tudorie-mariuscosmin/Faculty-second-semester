package ro.ase.acs.classes;

import java.util.concurrent.Callable;

public class ArraySummingCallable implements Callable<Long> {
	private int[] array;
	private int startIndex;
	private int endIndex;
	
	public ArraySummingCallable( int[] array, int start, int end) {
		this.array = array;
		startIndex = start;
		endIndex = end;
	}
	
	
	@Override
	public Long call() throws Exception {
		long sum = 0;
		for(int i=startIndex; i<endIndex ;i++) {
			sum += array[i];
		}
		return sum;
	}

	

}
