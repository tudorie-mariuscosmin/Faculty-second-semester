package tcpServer;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.util.Scanner;

public class TcpClient extends Thread {
	private Socket socket;
	
	public TcpClient( Socket socket) {
		this.socket = socket;
	}
	
	@Override
	public void run() {
		super.run();
		while(true) {
			InputStream inputStream;
			try {
				inputStream = socket.getInputStream();
				DataInputStream dataInputStream = new DataInputStream(inputStream);
				String msg = dataInputStream.readUTF();
				System.out.println(msg);
			} catch (IOException e) {
				e.printStackTrace();
			}
			
		}
	}

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		try(Socket socket = new Socket("localhost", 7777)){
			TcpClient client = new TcpClient(socket);
			client.start();
			
			while(true) {
				OutputStream outputStream = socket.getOutputStream();
				DataOutputStream dataOutputStream = new DataOutputStream(outputStream);
				dataOutputStream.writeUTF(scanner.nextLine());
			}
			
			
		}catch(Exception e) {
			e.printStackTrace();
		}

	}

}
