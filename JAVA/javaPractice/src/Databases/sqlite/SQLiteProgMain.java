package Databases.sqlite;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SQLiteProgMain {

	public static void main(String[] args) {
		Connection connection = null;
		try {
			Class.forName("org.sqlite.JDBC");
			connection= DriverManager.getConnection("jdbc:sqlite:database.db");
			connection.setAutoCommit(false);
			
			createTables(connection);
			insertData(connection);
			selectData(connection);
			
			
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (SQLException e) {
			e.printStackTrace();
		}finally {
			if(connection!=null)
				try {
					connection.close();
				} catch (SQLException e) {
					e.printStackTrace();
				}
		}
	}
	
	
	public static void createTables(Connection connection) {
		String sqlDrop ="DROP TABLE IF EXISTS employees";
		String sqlCreate = "Create table employees(id Integer primary key, name text, birthdate long, adress text, salary real);";
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
		String sql = "insert into employees values(0, 'Tudorie Marius', 1589880940, 'Marasesti', 4000);";
		Statement statement;
		String sqlParams = "insert into employees(name, birthdate, adress, salary) values(?,?,?,?);";
		try {
			statement = connection.createStatement();
			statement.executeUpdate(sql);
			statement.close();
			connection.commit();
			PreparedStatement preparedStatement = connection.prepareStatement(sqlParams);
			preparedStatement.setString(1, "Marius Cosmin");
			preparedStatement.setLong(2, Date.valueOf("1999-09-24").getTime());
			preparedStatement.setString(3, "marsesti 35");
			preparedStatement.setDouble(4, 543.2);
			preparedStatement.executeUpdate();
			preparedStatement.close();
			connection.commit();

		} catch (SQLException e) {
			e.printStackTrace();
		}
		
	}
	
	public static void selectData(Connection connection) {
		String sql = "select * from employees";
		
		Statement statement;
		try {
			statement = connection.createStatement();
			ResultSet set =  statement.executeQuery(sql);
			while(set.next()) {
				int id = set.getInt("id");
				System.out.println("id: "+id);
				String name = set.getString("name");
				System.out.println("name: "+name);
				Date birthdate = new Date(set.getLong("birthdate"));
				System.out.println("date: "+ birthdate);
				String adress = set.getString("adress");
				System.out.println("adress: "+adress);
				double salary = set.getDouble("salary");
				System.out.println("salary: "+ salary);
				System.out.println("--------------------");
			}
			set.close();
			statement.close();

		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
