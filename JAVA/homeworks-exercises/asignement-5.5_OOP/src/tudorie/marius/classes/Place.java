package tudorie.marius.classes;

public class Place {
public int[] time;
	
	public Place() {
		this.time=null;
	}
	
	public Place(int []t) {
		if(t!=null) {
			this.time=new int[t.length];
			for(int i=0; i<t.length; i++) {
				this.time[i]=t[i];
			}
		}
	}
	
	public void TimeMm() {
		int min=0,max=0;
		if(this.time!=null) {
			min=max=this.time[0];
			for(int i=0; i<this.time.length;i ++) {
				if(this.time[i]>max) {
					max=this.time[i];
				}
				if(this.time[i]<min) {
					min=this.time[i];
				}
			}
		}
		
		System.out.println("Max: "+max+"\nMin: "+min);
		
	}
}
