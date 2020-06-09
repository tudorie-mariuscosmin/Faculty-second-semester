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
			connection = DriverManager.getConnection("jdbc:sqlite:database.db");
			connection.setAutoCommit(false);
			
			createTable(connection);
			insertData(connection);
			selectDate(connection);
			
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}finally {
			if(connection != null)
				try {
					connection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
		}
	}
	
	public static void createTable(Connection connection) {
		String sqlDrop = "DROP TABLE IF EXISTS employees";
		String sqlCreate = "CREATE TABLE employees(id INTEGER PRIMARY KEY, name TEXT, birthdate LONG, adress TEXT, salary REAL);";
		try {
			Statement statement = connection.createStatement();
			statement.executeUpdate(sqlDrop);
			statement.executeUpdate(sqlCreate);
			statement.close();
			connection.commit();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	
	public static void insertData(Connection connection) {
		String sqlInsert = "INSERT INTO employees VALUES(0, 'Gigel Ionescu', 1589880940, 'Str Marasesti nr 35', 4000);";
		
		String sqlParams = "INSERT INTO employees(name, birthdate, adress, salary) VALUES(?,?,?,?);";
		
		Statement statement;
		try {
			statement = connection.createStatement();
			statement.execute(sqlInsert);
			statement.close();
			connection.commit();
			
			PreparedStatement preparedStatement = connection.prepareStatement(sqlParams);
			preparedStatement.setString(1, "Ion Pop");
			preparedStatement.setLong(2, Date.valueOf("1999-09-24").getTime());
			preparedStatement.setString(3, "Marasesti");
			preparedStatement.setDouble(4, 3350);
			preparedStatement.executeUpdate();
			preparedStatement.close();
			connection.commit();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
	
	public static void selectDate(Connection connection) {
		String select = "SELECT * FROM employees";
		Statement statement;
		try {
			statement = connection.createStatement();
			ResultSet result = statement.executeQuery(select);
			while(result.next()) {
				int id = result.getInt("id");
				System.out.println("id: "+id);
				String name = result.getString("name");
				System.out.println("name: "+name);
				long birthdate = result.getLong("birthdate");
				System.out.println("Birthdate: "+new Date(birthdate) );
				String adress = result.getString("adress");
				System.out.println("adress: " +adress);
				double salary =  result.getDouble("salary");
				System.out.println("salary: "+ salary);
			}
			result.close();
			statement.close();
		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
	
}
