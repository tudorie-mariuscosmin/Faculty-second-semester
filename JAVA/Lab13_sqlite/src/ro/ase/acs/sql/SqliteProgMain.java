package ro.ase.acs.sql;


import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public abstract class SqliteProgMain {

	public static void main(String[] args) {
		Connection connection = null;
		try {
			Class.forName("org.sqlite.JDBC");
			connection = DriverManager.getConnection("jdbc:sqlite:");
			createTable(connection);
			insertData(connection);
			
		}catch(ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally {
			if(connection!=null) {
				try {
					connection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}
		}

	}
	
	public static void createTable(Connection connection) {
		String sqlDrop = "DROP TABLE IF EXISTS employees";
		String sqlCreate = "CREATE TABLE employees (id INTEGER PRIMARY KEY, name TEXT, birthdate LONG, adress TEXT, salary REAL)";
		
		Statement statement;
		try {
			statement = connection.createStatement();
			statement.executeUpdate(sqlDrop);
			statement.executeUpdate(sqlCreate);
			statement.close();
			connection.commit();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
	
	public static void insertData(Connection connection) {
		String sqlInsert = "INSERT INTO employees VALUES(0, 'Gigel Ionescu', 1589880940, 'Stefan cel Mare no 20', 2000) ";
		String sqlInsertWithParams = "INSERT INTO employees(name, birthdate, adress, salary) VALUES (?, ?, ?, ?)";
		try {
			Statement statement = connection.createStatement();
			statement.executeUpdate(sqlInsert);
			statement.close();
			connection.commit();
			
			
			
			PreparedStatement preparedStatement = connection.prepareStatement(sqlInsertWithParams);
			preparedStatement.setString(1, "Ion Popescu");
			preparedStatement.setLong(2, Date.valueOf("1995-01-05").getTime());
			preparedStatement.setString(3, "Bucuresti, romania");
			preparedStatement.setDouble(3, 2500);
			preparedStatement.executeUpdate();
			preparedStatement.close();
			connection.commit();
			
			
			
		} catch (SQLException e) {
			e.printStackTrace();
		}

	}
	
	public static void selectDate(Connection connection) {
		String sql = "SELECT * FROM employees";
		Statement statement;
		try {
			statement = connection.createStatement();
			ResultSet rs =  statement.executeQuery(sql);
			
			while(rs.next()) {
				int id = rs.getInt("id");
				System.out.println("id: "+ id);
				String name = rs.getString("name");
				System.out.println("name: "+ name);
				long birthdate = rs.getLong("birthdate");
				System.out.println("birthdate: "+ new Date(birthdate));
				String adress = rs.getString("adress");
				System.out.println("adress:"+ adress);
				double salary = rs.getDouble("salary");
				System.out.println("salary: "+salary);
				
			}
			rs.close();
			statement.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
		
	}
}
