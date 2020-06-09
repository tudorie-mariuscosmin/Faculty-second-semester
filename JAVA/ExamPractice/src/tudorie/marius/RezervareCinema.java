package tudorie.marius;

import java.util.Arrays;
import java.util.Date;

public class RezervareCinema implements Cloneable {
	private String title;
	private Date data;
	int[] rand;
	int[] loc;
	
	public RezervareCinema(String title) {
		this.title = title;
		data = new Date();
	}
	
	public void addLoc(int rand, int loc) {
		if(this.rand == null && this.loc== null ) {
			this.rand = new int[1];
			this.loc = new int[1];
			this.rand[0] = rand;
			this.loc[0] = loc;
		}else {
			int[] temploc = this.loc;
			int[] temprand = this.rand;
			this.loc = new int[temploc.length+1];
			this.rand = new int[temprand.length+1];
			for(int i=0; i<temploc.length; i++) {
				this.loc[i] = temploc[i];
				this.rand[i] = temprand[i];
			}
			this.loc[temploc.length] =loc;
			this.rand[temprand.length] = rand;
		}
	}
	
	
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(title);
		builder.append(",");
		builder.append(data);
		builder.append(",");
		for(int i=0; i< loc.length; i++) {
			builder.append(loc[i]+",");
		}
		for(int i=0; i< rand.length; i++) {
			builder.append(rand[i]+",");
		}
		return builder.toString();
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	@Override
	protected Object clone() throws CloneNotSupportedException {
		RezervareCinema copy = new RezervareCinema(this.title);
		copy.loc = new int[this.loc.length];
		copy.rand = new int[this.rand.length];
				
		System.arraycopy(this.loc, 0, copy.loc, 0, this.loc.length);
		System.arraycopy(this.rand, 0, copy.rand, 0, this.rand.length);
		return copy;
		
	}

}
