package udpServer;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;
import java.util.Scanner;

public class ClientUdp extends Thread{
	private DatagramSocket socket;
	
	public ClientUdp() {
		try {
			this.socket = new DatagramSocket();
		} catch (SocketException e) {
			e.printStackTrace();
		}
	}
	
	@Override
	public void run() {
		super.run();
		while(true) {
			byte[] buffer = new byte[256];
			DatagramPacket recived = new DatagramPacket(buffer, buffer.length);
			
			try {
				socket.receive(recived);
				String msgRecived = new String(recived.getData());
				System.out.println(msgRecived);
			} catch (IOException e) {
				e.printStackTrace();
			}
			
		}
	}
	
	
	public static void main(String[] args) {
		ClientUdp client = new ClientUdp();
		Scanner scanner = new Scanner(System.in);
		client.start();
		try{
			
			
			InetAddress serverAddress = InetAddress.getByName("localhost");
			int serverPort = 7777;
			
			while(true) {
				String msg = scanner.nextLine();
				byte[] bytes = msg.getBytes();
				DatagramPacket packet = new DatagramPacket(bytes, bytes.length, serverAddress, serverPort);
				client.socket.send(packet);
			
			}
		}catch(IOException e) {
			e.printStackTrace();
		}

	}

}
