package ro.ase.acs.client;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.Scanner;

public class UDPClient extends Thread {

	private DatagramSocket socket;
	
	public UDPClient() {
		try {
			socket = new DatagramSocket();
		} catch (SocketException e) {
			e.printStackTrace();
		}
		
	}
	
	@Override
	public void run() {
		super.run();
		while(true) {
			byte[] buffer = new byte[256];
			DatagramPacket recivedP = new DatagramPacket(buffer, buffer.length);
			try {
				socket.receive(recivedP);
				String recivedMsg = new String(recivedP.getData());
				System.out.println(recivedMsg);
			} catch (IOException e) {
				e.printStackTrace();
			}
			
		}
	}
	
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		UDPClient client = new UDPClient();
		client.start();
		try{
			InetAddress serverAdress = InetAddress.getByName("localhost");
			int serverPort = 7777;
			while(true) {
				String message = scanner.nextLine();
				byte[] bytes = message.getBytes();
				
				
				DatagramPacket packet = new DatagramPacket(bytes, bytes.length, serverAdress, serverPort);
				client.socket.send(packet);
				
				
			}
			
		}catch(IOException e) {
			e.printStackTrace();
		}
		
		scanner.close();
	}

}
