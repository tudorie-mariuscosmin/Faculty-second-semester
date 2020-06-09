package ro.ase.acs.main;

public class B extends A{
	public B(int id, String nume) {
		super(id, nume);
		// TODO Auto-generated constructor stub
	}

	public B() {};
	protected int b = 100;
	
	public String getCalificativ() {
		return "Foarte Bine";
	}
}
