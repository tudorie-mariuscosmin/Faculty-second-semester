package tcpServer;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.List;
import java.util.Vector;

public class TcpServer extends Thread {
	private Socket socket;
	private static List<Socket> clients = new Vector<Socket>();
	
	
	
	public TcpServer(Socket socket) {
		this.socket = socket;
	}
	
	public String receive() {
		InputStream inputStream;
		try {
			inputStream = socket.getInputStream();
			DataInputStream dataInputStream =  new DataInputStream(inputStream);
			String msg = dataInputStream.readUTF();
			return msg;
		} catch (IOException e) {
			e.printStackTrace();
		}
		return "";
		
	}
	
	@Override
	public void run() {
		super.run();
		while(true) {
		String msg = receive();
		send(msg);
		}
	}
	public void send(String msg) {
		for(Socket s: clients) {
			OutputStream outputStream;
			try {
				outputStream = s.getOutputStream();
				DataOutputStream dataOutputStream = new DataOutputStream(outputStream);
				dataOutputStream.writeUTF(msg);
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
		}
	}
	
	
	public static void main(String[] args) {
		
		
		try(ServerSocket server = new ServerSocket(7777)){
			System.out.println("server started on port 7777");
			while(true) {
				Socket socket =  server.accept();
				clients.add(socket);
				TcpServer serverinstance = new TcpServer(socket);
				serverinstance.start();
			}
		
			
			
			
		}catch(IOException e) {
			e.printStackTrace();
		}
		

	}

}
