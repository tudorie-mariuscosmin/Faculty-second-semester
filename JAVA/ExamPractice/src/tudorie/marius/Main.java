package tudorie.marius;

import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.nio.Buffer;
import java.util.ArrayList;
import java.util.List;

public class Main {

	public static void main(String[] args) {

		
		RezervareCinema r1 = new RezervareCinema("Marius");
		r1.addLoc(2, 3);
		r1.addLoc(4, 43);
		RezervareCinema r2 = null;
		try {
			r2 = (RezervareCinema)r1.clone();
		} catch (CloneNotSupportedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		RezervareCinema r3 = new RezervareCinema("ion");
		r3.addLoc(6, 32);
		
		List<RezervareCinema> list = new ArrayList<RezervareCinema>();
		list.add(r1);
		list.add(r2);
		list.add(r3);
		for(RezervareCinema i : list) {
			System.out.println( i);
		}
		
		try{
			FileOutputStream fileOutputStream = new FileOutputStream("rezervari.csv");
			OutputStreamWriter outputStreamWriter  = new OutputStreamWriter(fileOutputStream);
			BufferedWriter writer = new BufferedWriter(outputStreamWriter);
			for(RezervareCinema i : list) {
				writer.write(i.toString());
				writer.write(System.lineSeparator());
			
			}
			writer.close();

		} catch (IOException e) {
			e.printStackTrace();
		}
		
		
		
	}

}
