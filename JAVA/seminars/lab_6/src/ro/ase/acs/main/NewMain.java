package ro.ase.acs.main;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.Scanner;

import ro.ase.acs.classes.Car;

public class NewMain {

	public static void main(String[] args) {
//		Scanner scanner = new Scanner(System.in);
//		String name = "";
//		System.out.println("name:");
//		name = scanner.nextLine();
//		System.out.println("age:");
//		int age = scanner.nextInt();
//		System.out.println("name: "+ name +" age: " +age);
//		scanner.close();
		
		Car car = new Car("tesla", 200, "black", 3000);
		
		try {
			FileOutputStream fileOutputStream = new FileOutputStream("car.txt");
			OutputStreamWriter streamWriter = new OutputStreamWriter(fileOutputStream);
			BufferedWriter writer = new BufferedWriter(streamWriter);
			writer.write(car.getName());
			writer.write(System.lineSeparator());
			Integer speed = car.getSpeed();
			writer.write(speed.toString());
			writer.write(System.lineSeparator());
			writer.write(car.getColor());
			writer.write(System.lineSeparator());
			Integer capacity = car.getCapacity();
			writer.write(capacity.toString());
			writer.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		
		try {
			FileInputStream fileInputStream = new FileInputStream("car.txt");
			InputStreamReader streamReader = new InputStreamReader(fileInputStream);
			BufferedReader reader = new BufferedReader(streamReader);
			
			String name =  reader.readLine();
			int speed = Integer.parseInt(reader.readLine());
			String color = reader.readLine();
			int capacity = Integer.parseInt(reader.readLine());
			reader.close();
			Car c2 =  new Car(name, speed , color, capacity);
			System.out.println(c2);
			
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		
		try {
			FileOutputStream binaryOutputStream = new FileOutputStream("car.bin");
			DataOutputStream outputStream = new DataOutputStream(binaryOutputStream);
			outputStream.writeUTF(car.getName());
			outputStream.writeInt(car.getSpeed());
			outputStream.writeUTF(car.getColor());
			outputStream.writeInt(car.getCapacity());
			outputStream.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		try {
			FileInputStream binInputStream = new FileInputStream("car.bin");
			DataInputStream dataInputStream = new DataInputStream(binInputStream);
			String name =  dataInputStream.readUTF();
			int speed = dataInputStream.readInt();
			String color = dataInputStream.readUTF();
			int capacity = dataInputStream.readInt();
			dataInputStream.close();
			Car c3 = new Car(name, speed, color , capacity);
			System.out.println(c3);
					
		}catch (IOException e) {
			e.printStackTrace();
		}
		
		
		car.serialize();
		
		try {
			Car c4 = Car.deserialize();
			System.out.println(c4);
		} catch (ClassNotFoundException | IOException e) {
			e.printStackTrace();
		}
		
		

	}

}
