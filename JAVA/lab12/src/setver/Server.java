package setver;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.URL;
import java.net.URLConnection;
//import java.net.http.HttpClient;
import java.util.List;
import java.util.Vector;

public class Server extends Thread {
	
	private static List<Socket> clients = new Vector<Socket>();
	
	private Socket socket;

	public Server(Socket socket) {
		this.socket = socket;
		
	}
	
	private String recive() {
		InputStream inputStream;
		try {
			inputStream = socket.getInputStream();
			DataInputStream dataInputStream = new DataInputStream(inputStream);
			String message = dataInputStream.readUTF();
			return message;
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return "";	
	}
	
	private void send(String message) {
		for(Socket s : clients) {
			OutputStream outputStream;
			try {
				outputStream = socket.getOutputStream();
				DataOutputStream dataOutputStream = new DataOutputStream(outputStream);
				dataOutputStream.writeUTF(message);
				
			} catch (IOException e) {
				e.printStackTrace();
			}
		
		}
	}
	
	

	@Override
	public void run() {
		
		super.run();
		while(true) {
			String message = recive();
			send(message);
		}
	}

	public static void main(String[] args) {
	
		try(ServerSocket server = new ServerSocket(7777)){
			System.out.println("server running on port 7777");
			URL url = new URL("http://google.ro");
			URLConnection connection =  url.openConnection();
			InputStream inputStream =  connection.getInputStream();
			InputStreamReader  reader = new InputStreamReader(inputStream);
			BufferedReader bufferreader = new BufferedReader(reader);
			System.out.println(bufferreader.readLine());
			
			//HttpClient client = new HttpClient
			
			
			
			while(true) {
				Socket socket = server.accept();
				clients.add(socket);
				Server serverInstance = new Server(socket);
				serverInstance.start();
			}
			
			
			
			
			
		}catch(Exception e) {
			e.printStackTrace();
		}

	}

}
