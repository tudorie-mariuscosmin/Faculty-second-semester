package ro.ase.acs.main;

public class A {
	private int id;
	private String nume;
	
	 public A(int id, String nume) {
		 this.id = id;
		 this.nume = nume;
		 boolean t ;
	}
	public A() {}
	 private String getCalificativ() {
		 return "Bine";
	 }
	 public String GetInfo() {
		 return this.getCalificativ();
	 }
	 
	 @Override
	public String toString() {
		return id+" "+nume;
	}
}
