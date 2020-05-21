package ro.ase.acs.noSql;

import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoDatabase;

public class MongoProgMain {

	public static void main(String[] args) {
		MongoClient client = new MongoClient("localhost", 27017);
		MongoDatabase db = client.getDatabase("test");
		
		if(db.getCollection(("employees") != null ){
			db.getCollection("employees").drop();
		}
		
		db.createCollection("employees");
		
		
		

	}

}
