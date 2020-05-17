package ro.ase.acs.server;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class UDPServer {

	public static void main(String[] args) {
		try(DatagramSocket socket = new DatagramSocket(8888)){
			System.out.println("server started o  port 8888");
			byte[] buffer = new byte[256];
			DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
			socket.receive(packet);
			String recivedMessage = new String(packet.getData());
			System.out.println(recivedMessage);
			
			String message = "hi";
			byte[] bytes = message.getBytes();
			DatagramPacket packetToBeSent = new DatagramPacket(bytes, bytes.length);
			
			
			
		}catch(IOException e) {
			e.printStackTrace();
		}

	}

}
