package ro.ase.acs.client;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;

public class UDPClient {

	public static void main(String[] args) {
		try(DatagramSocket socket = new DatagramSocket()){
			
			InetAddress  serverAdress = InetAddress.getByName("localhost");
			int serverPort = 8888;
			
			while(true) {
				String message = "Hello";
				byte[] bytes = message.getBytes();
				DatagramPacket packet = new DatagramPacket(bytes, bytes.length, serverAdress, serverPort);
				socket.send(packet);
				
				byte[] buffer = new byte[256];
				DatagramPacket recivePacket = new DatagramPacket(buffer, buffer.length);
				socket.receive(recivePacket);
				String reciveMessage = new String(recivePacket.getData());
				System.out.println(reciveMessage);
			
			}
			
		} catch (SocketException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}

}
