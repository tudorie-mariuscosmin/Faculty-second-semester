package udpServer;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.Scanner;

public class ServerUdp extends Thread {
	private DatagramSocket socket;
	private int port = 7777;
	
	public ServerUdp() {
		try {
			this.socket = new DatagramSocket(port);
			System.out.println("server runing on port "+ port);
		} catch (SocketException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void run() {
		super.run();
		while(true) {
			byte[] buffer = new byte[256];
			DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
			
			try {
				socket.receive(packet);
				String msg = new String(packet.getData());
				System.out.println(msg);
				
			} catch (IOException e) {
				e.printStackTrace();
			}
		
		}
	}

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		ServerUdp server = new ServerUdp();
		try {
			byte[] buffer = new byte[256];
			DatagramPacket packet = new DatagramPacket(buffer, buffer.length);
			
			server.socket.receive(packet);
			String msg = new String(packet.getData());
			System.out.println(msg);
			
			InetAddress clientAddress = packet.getAddress();
			int clientPort = packet.getPort();
			
			server.start();
			while(true) {
				String sendMgs = scanner.nextLine();
				byte[] bytes = sendMgs.getBytes();
				DatagramPacket send = new DatagramPacket(bytes, bytes.length, clientAddress, clientPort);
				server.socket.send(send);
			
			}
		} catch (SocketException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		scanner.close();
		

	}

}
