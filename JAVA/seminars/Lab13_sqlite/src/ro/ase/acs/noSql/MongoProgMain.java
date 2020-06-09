package ro.ase.acs.noSql;


import java.util.Date;

import org.bson.Document;

import com.mongodb.MongoClient;
import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;

public class MongoProgMain {

	public static void main(String[] args) {
		MongoClient client = new MongoClient("localhost", 27017);
		MongoDatabase db = client.getDatabase("java");
		
		if(db.getCollection("employees")!=null)
			db.getCollection("employees").drop();
		
		
		db.createCollection("employees");
		
		
		Document doc = new Document().
									append("name" , "Tudorie Marius").
									append("birthdate" , new Date()).
									append("adress", "Str Marasesti nr 35").
									append("salary", 2500);
		
		Document doc2 = new Document().append("name", "Marius");
		MongoCollection<Document> collection =  db.getCollection("employees");
		collection.insertOne(doc);
		collection.insertOne(doc2);
		
		
		FindIterable<Document> result= collection.find();
		MongoCursor<Document> cursor = result.iterator();
		while(cursor.hasNext()) {
			System.out.println(cursor.next());
		}
		
		client.close();
		
		
		
	}

}
