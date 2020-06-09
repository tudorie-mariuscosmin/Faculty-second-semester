package Databases.sqlite;

import java.util.Date;
import java.util.Iterator;

import org.bson.Document;

import com.mongodb.MongoClient;
import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoCursor;
import com.mongodb.client.MongoDatabase;

public class mogoDB {

	public static void main(String[] args) {
		MongoClient client = new MongoClient("localhost", 27017);

		MongoDatabase database = client.getDatabase("testJava");
		
		if(database.getCollection("employees")!=null)
			database.getCollection("employees").drop();
			
		database.createCollection("employees");
		
		Document doc = new Document();
		doc.append("name", "Marius Cosmin Tudorie");
		doc.append("birthdate", new Date());
		doc.append("adress", "la bambucea");
		doc.append("salary", 54862);
		
		MongoCollection<Document> collection =  database.getCollection("employees");
		collection.insertOne(doc);
		
		
		
		FindIterable<Document> it =  collection.find();
		MongoCursor<Document> res = it.iterator();
		while(res.hasNext()) {
			System.out.println(res.next());
		}
		client.close();
		
		
		
	}

}
