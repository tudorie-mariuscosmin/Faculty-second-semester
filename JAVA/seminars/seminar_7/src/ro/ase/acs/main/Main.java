package ro.ase.acs.main;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Random;
import java.util.stream.Collector;
import java.util.stream.Collectors;

import ro.ase.acs.classes.Sum;
import ro.ase.acs.interfaces.BinaryOperator;
import ro.ase.acs.interfaces.Movable;
import ro.ase.acs.interfaces.UnaryOperator;

public class Main {
	
	public static int transform(int x) {
		return (x*2)+10;
	}

	public static void main(String[] args) {
		BinaryOperator operator = new Sum();
		operator = new BinaryOperator() {
			
			@Override
			public double operate(double operand1, double operand2) {
				return  operand1 - operand2;
			}
		};
		
		System.out.println(operator.operate(3, 5));
		
		
		operator = (o1, o2)->o1*o2;
		
		operator = (a,b)->{
			return (a+b)/2;
		};
		System.out.println(operator.operate(3, 6));
		
		Movable m = ()-> System.out.println("The car is moving");
		m.move();
		
		UnaryOperator op = o -> ++o;
		
		System.out.println(op.operate(5));
		
		
		
		
		List<Integer> list = Arrays.asList(3,4,5,6,7,8,9,14,12);
		
		long nb =  list.stream().filter(e-> e%2 ==0).count();
		System.out.println(nb);
		
		List<Integer> newList = list.stream().sorted().distinct().filter(e -> e < 8 ).collect(Collectors.toList() );
		
		
		for (int i : newList)
			System.out.println(i);
		
		
		List<String> strings = Arrays.asList("asfdafd", "asffdasfaf", "afdscea", "a", "abc", "gfbers", "cd");
		
		String s= strings.stream().filter(e-> e.startsWith("a")).collect(Collectors.joining(" || "));
		System.out.println(s);
		
		list.stream().distinct().sorted().map(e->e*10).forEach(e-> System.out.println(e));
		Random random = new Random();
		random.ints().limit(7).sorted().forEach(System.out::println);
		
		
		list.stream().map(Main::transform).forEach(System.out::println);
		
	}

}
